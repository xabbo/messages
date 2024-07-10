package messages

import (
	"fmt"
	"strings"
)

// MsgIdentifier defines a message direction and name.
type MsgIdentifier struct {
	Dir  Direction
	Name string
}

// ClientMsgIdentifier defines a client, direction and message name.
type ClientMsgIdentifier struct {
	Client Client
	Dir    Direction
	Name   string
}

// ClientMsgName defines a client and message name.
type ClientMsgName struct {
	Client Client
	Name   string
}

// Parse parses the string into a client specifier and message name, separated by a colon character.
func (n *ClientMsgName) Parse(s string) (err error) {
	split := strings.Split(s, ":")
	var client Client
	if len(split) != 2 {
		goto invalid
	}
	if len([]rune(split[0])) != 1 {
		goto invalid
	}
	if !client.FromRune([]rune(split[0])[0]) {
		goto invalid
	}
	*n = ClientMsgName{client, split[1]}
	return
invalid:
	err = fmt.Errorf("invalid client message name: %q", s)
	return
}

// CleanName cleans a message name ending with "[Message]Event" or "[Message]Composer".
func CleanName(dir Direction, name string) (result string) {
	var cut bool
	switch dir {
	case In:
		result, cut = strings.CutSuffix(name, "Event")
	case Out:
		result, cut = strings.CutSuffix(name, "Composer")
	}
	if cut {
		result = strings.TrimSuffix(result, "Message")
	}
	return
}
