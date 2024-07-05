package messages

import (
	"fmt"
	"strings"
)

// MsgMapEntry defines an entry in a message map.
// A name for each client may be defined, as well as multiple no-merge directives, and an end-of-line comment.
type MsgMapEntry struct {
	Unity, Flash, Shockwave string
	NoMerge                 []ClientMsgName
	Comment                 string
}

// Merge merges message names from `other` into this instance.
// It returns a MergeConflict if there is a conflict.
func (dst *MsgMapEntry) Merge(src *MsgMapEntry) (op MergeOp) {
	op.Src = src
	op.Dst = dst
	op.Prev = *dst
	for _, client := range Clients {
		switch mergeMsgName(dst.Ptr(client), src.Ptr(client)) {
		case MergeConflict:
			op.Result = MergeConflict
			op.Conflict = client
			return
		case MergeOk:
			op.Result = MergeOk
		}
	}
	if op.Result != MergeConflict {
		dst.Comment = mergeComments(dst.Comment, src.Comment)
	}
	return
}

// mergeMsgName copies src into dst if src is non-empty.
// If the two strings are equal, casing is updated from src into dst.
// If src and dst are different, there is a conflict, and false is returned.
func mergeMsgName(dst, src *string) MergeResult {
	switch {
	case *src == "":
		return NoMerge
	case *dst != "" && !strings.EqualFold(*dst, *src):
		return MergeConflict
	default:
		if strings.EqualFold(*dst, *src) {
			return NoMerge
		}
		*dst = *src
		return MergeOk
	}
}

func mergeComments(dst, src string) string {
	dst = formatComment(dst)
	src = formatComment(src)
	if dst != "" && src != "" && !strings.EqualFold(dst, src) {
		dst += " " + src
	}
	return dst
}

func formatComment(comment string) string {
	comment = strings.TrimSpace(comment)
	if comment != "" && !strings.HasSuffix(comment, ".") {
		comment += "."
	}
	return comment
}

func (res MergeResult) String() string {
	switch res {
	case NoMerge:
		return "NoMerge"
	case MergeOk:
		return "MergeOk"
	case MergeConflict:
		return "MergeConflict"
	default:
		return ""
	}
}

// CheckMergeAll checks whether the src entry can be merged into dst.
func CheckMergeAll(dst, src MsgMapEntry) (merge MergeResult) {
	merge = NoMerge
	for _, client := range Clients {
		switch CheckMerge(dst.Get(client), src.Get(client)) {
		case MergeOk:
			merge = MergeOk
		case MergeConflict:
			return MergeConflict
		}
	}
	return
}

// CheckMerge checks whether the src name can be merged into dst.
func CheckMerge(dst, src string) MergeResult {
	switch {
	case src == "" || strings.EqualFold(src, dst):
		return NoMerge
	case dst != "":
		return MergeConflict
	default:
		return MergeOk
	}
}

// Parse parses a string to a message map entry.
func (entry *MsgMapEntry) Parse(s string) (err error) {
	commentSplit := strings.SplitN(s, ";", 2)
	if len(commentSplit) == 0 {
		err = fmt.Errorf("empty line")
		return
	}

	*entry = MsgMapEntry{}

	var processed Client

	fields := strings.Fields(commentSplit[0])
	for _, field := range fields {
		field, noMerge := strings.CutPrefix(field, "!")
		split := strings.Split(field, ":")
		if len(split) != 2 {
			err = fmt.Errorf("invalid token: %q", field)
			return
		}

		clientRunes, name := split[0], split[1]
		for _, r := range clientRunes {
			var client Client
			if !client.FromRune(r) {
				err = fmt.Errorf("unknown client char: %c", r)
				return
			}
			if noMerge {
				entry.NoMerge = append(entry.NoMerge, ClientMsgName{client, name})
				continue
			}
			if processed&client > 0 {
				err = fmt.Errorf("duplicate client char: %c", r)
				return
			}
			processed |= client
			entry.Set(client, name)
		}
	}

	if len(commentSplit) >= 2 {
		entry.Comment = formatComment(commentSplit[1])
	}
	return
}

// String formats the message map entry to a string.
func (entry *MsgMapEntry) String() (result string) {
	var fields []string
	processed := Client(0)

	for i := range Clients {
		if processed&Clients[i] > 0 {
			continue
		}
		processed |= Clients[i]
		name := entry.Get(Clients[i])
		if name == "" {
			continue
		}
		identifier := string(Clients[i].Rune())
		for j := range Clients {
			if processed&Clients[j] > 0 {
				continue
			}
			if strings.EqualFold(entry.Get(Clients[j]), name) {
				identifier += string(Clients[j].Rune())
				processed |= Clients[j]
			}
		}
		fields = append(fields, identifier+":"+name)
	}

	for _, noMerge := range entry.NoMerge {
		fields = append(fields, "!"+string(noMerge.Client.Rune())+":"+noMerge.Name)
	}

	result = strings.Join(fields, " ")
	if entry.Comment != "" {
		result += " ; " + entry.Comment
	}
	return
}

// Ptr returns a pointer to the message name for the specified client.
func (names *MsgMapEntry) Ptr(client Client) *string {
	switch client {
	case Unity:
		return &names.Unity
	case Flash:
		return &names.Flash
	case Shockwave:
		return &names.Shockwave
	default:
		panic(fmt.Errorf("invalid client: %s", client))
	}
}

// Get returns the message name for the specified client.
func (names *MsgMapEntry) Get(client Client) string {
	switch client {
	case Unity:
		return names.Unity
	case Flash:
		return names.Flash
	case Shockwave:
		return names.Shockwave
	default:
		panic(fmt.Errorf("invalid client: %s", client))
	}
}

// Set sets the message name for the specified client.
func (names *MsgMapEntry) Set(client Client, name string) {
	switch client {
	case Unity:
		names.Unity = name
	case Flash:
		names.Flash = name
	case Shockwave:
		names.Shockwave = name
	default:
		panic(fmt.Errorf("invalid client: %s", client))
	}
}

// CompareMsgs compares message map entries based on their name.
func CompareMsgs(a, b MsgMapEntry) int {
	return strings.Compare(a.Name(), b.Name())
}

// Name returns the first non-empty message name in the order of [Clients].
func (msg MsgMapEntry) Name() string {
	for _, client := range Clients {
		name := msg.Get(client)
		if name != "" {
			return name
		}
	}
	return ""
}
