package messages

import (
	"bufio"
	"fmt"
	"io"
	"os"
	"slices"
	"strings"

	"golang.org/x/exp/maps"
)

// MessageMap maps client specific message names to MsgMapEntry.
type MessageMap struct {
	m map[ClientMsgIdentifier]*MsgMapEntry
}

type MergeResult int

const (
	NoMerge       MergeResult = iota // NoMerge indicates that the entry was not merged.
	MergeOk                          // MergeOk indicates that the entry was successfully merged.
	MergeAdd                         // MergeAdd indicates that the entry was newly added.
	MergeConflict                    // MergeConflict indicates that the entry was unable to be merged.
)

// MergeOp contains the result of a merge operation.
type MergeOp struct {
	Result   MergeResult  // MergeResult contains the result of the merge.
	Dst      *MsgMapEntry // Dst is a pointer to the destination entry.
	Src      *MsgMapEntry // Src is a poitner to the source entry.
	Prev     MsgMapEntry  // Prev is the state of the entry before the merge.
	Conflict Client       // Conflict reports the client message the conflict was detected for.
}

func NewMessageMap() MessageMap {
	return MessageMap{
		m: map[ClientMsgIdentifier]*MsgMapEntry{},
	}
}

func checkNoMerge(dst, src *MsgMapEntry) bool {
	for _, noMerge := range dst.NoMerge {
		if strings.EqualFold(src.Get(noMerge.Client), noMerge.Name) {
			return true
		}
	}
	for _, noMerge := range src.NoMerge {
		if strings.EqualFold(dst.Get(noMerge.Client), noMerge.Name) {
			return true
		}
	}
	return false
}

// AddOrMerge adds or merges the entry into the map and returns
// a MergeOp describing the result of the merge operation.
// The Result field will be MergeConflict if a conflict was detected.
func (msgMap MessageMap) AddOrMerge(dir Direction, src *MsgMapEntry) (op MergeOp) {
	// loop over src names
	for _, srcClient := range Clients {
		srcName := src.Get(srcClient)
		if srcName == "" || srcName == "-" {
			continue
		}
		// loop over clients to search keys
		for _, dstClient := range Clients {
			key := ClientMsgIdentifier{dstClient, dir, strings.ToLower(srcName)}
			if dst, ok := msgMap.m[key]; ok {
				if checkNoMerge(dst, src) {
					// do not merge
					continue
				}
				// must merge with existing
				op = dst.Merge(src)
				if op.Result != MergeConflict {
					for _, dstClient := range Clients {
						name := strings.ToLower(src.Get(dstClient))
						if name == "" {
							continue
						}
						msgMap.m[dstClient.Key(dir, name)] = dst
					}
				} else {
					op.Result = MergeConflict
				}
				return
			}
		}
	}
	if msgMap.add(dir, src) {
		op.Src = src
		op.Dst = src
		op.Result = MergeAdd
	}
	return
}

func (msgMap MessageMap) add(dir Direction, names *MsgMapEntry) bool {
	n := 0
	for _, client := range Clients {
		name := names.Get(client)
		if name != "" {
			key := ClientMsgIdentifier{client, dir, strings.ToLower(name)}
			msgMap.m[key] = names
			n++
		}
	}
	return n != 0
}

// All returns a sorted list of entries for the specified direction.
func (msgs MessageMap) All(dir Direction) []*MsgMapEntry {
	names := map[*MsgMapEntry]struct{}{}
	for k, msg := range msgs.m {
		if k.Dir == dir {
			names[msg] = struct{}{}
		}
	}
	slice := maps.Keys(names)
	slices.SortFunc(slice, func(a, b *MsgMapEntry) int {
		return CompareMsgs(*a, *b)
	})
	return slice
}

// LoadMapFile loads a message map from the specified file.
func LoadMapFile(name string) (msgs MessageMap, err error) {
	f, err := os.Open(name)
	if err != nil {
		return
	}
	defer f.Close()
	return LoadMap(f)
}

// LoadMap loads a message map from the specified io.Reader.
func LoadMap(r io.Reader) (msgs MessageMap, err error) {
	msgs = NewMessageMap()

	dir := Direction(-1)
	sc := bufio.NewScanner(r)

	ln := 0
	for sc.Scan() {
		line := strings.TrimSpace(sc.Text())
		ln++
		if line == "" {
			continue
		}

		if strings.HasPrefix(line, "[") && strings.HasSuffix(line, "]") {
			section := line[1 : len(line)-1]
			switch strings.ToLower(section) {
			case "incoming":
				dir = In
			case "outgoing":
				dir = Out
			default:
				err = fmt.Errorf("invalid section on line %d: %q", ln, section)
				return
			}
			continue
		}

		if dir != In && dir != Out {
			err = fmt.Errorf("line %d: content outside section", ln)
			return
		}

		var entry MsgMapEntry
		err = entry.Parse(line)
		if err != nil {
			err = fmt.Errorf("line %d: %w", ln, err)
			return
		}

		op := msgs.AddOrMerge(dir, &entry)
		switch op.Result {
		case MergeConflict:
			err = fmt.Errorf("line %d: merge conflict on %s message: %s -> %s", ln, op.Conflict, op.Src, op.Dst)
			return
		}
	}

	err = sc.Err()
	return
}

// Save saves the message map to the specified file.
func (msgs MessageMap) Save(name string) (err error) {
	f, err := os.OpenFile(name, os.O_RDWR|os.O_CREATE|os.O_TRUNC, 0644)
	if err != nil {
		return
	}
	defer f.Close()

	msgs.Write(f)
	return
}

// Write writes the message map to the specified writer.
func (msgs MessageMap) Write(out io.Writer) {
	w := bufio.NewWriter(out)
	defer w.Flush()

	n := 0
	for _, dir := range Directions {
		names := msgs.All(dir)
		if len(names) == 0 {
			continue
		}

		if n > 0 {
			w.WriteRune('\n')
		}
		n++

		switch dir {
		case In:
			w.WriteString("[Incoming]")
		case Out:
			w.WriteString("[Outgoing]")
		}
		w.WriteRune('\n')

		for _, names := range msgs.All(dir) {
			s := names.String()
			if s == "" {
				panic("empty string")
			}
			w.WriteString(s + "\n")
		}
	}
}
