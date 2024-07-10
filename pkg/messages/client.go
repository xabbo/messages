package messages

import (
	"strconv"
	"strings"
)

// Client is a bit field that specifies a client type.
type Client int

const (
	Unity Client = 1 << iota
	Flash
	Shockwave
)

// Clients contains the Unity, Flash and Shockwave clients.
var Clients = []Client{Unity, Flash, Shockwave}

func (client Client) String() string {
	switch client {
	case Unity:
		return "Unity"
	case Flash:
		return "Flash"
	case Shockwave:
		return "Shockwave"
	default:
		return strconv.Itoa(int(client))
	}
}

// Key returns a ClientMsgIdentifier for this client with the specified direction and name.
func (client Client) Key(dir Direction, name string) ClientMsgIdentifier {
	return ClientMsgIdentifier{client, dir, strings.ToLower(name)}
}

// Rune gets the single character identifier for this client.
func (client Client) Rune() rune {
	switch client {
	case Unity:
		return 'u'
	case Flash:
		return 'f'
	case Shockwave:
		return 's'
	default:
		return '?'
	}
}

// FromRune converts the character identifier into a Client.
func (client *Client) FromRune(r rune) bool {
	switch r {
	case 'u':
		*client = Unity
	case 'f':
		*client = Flash
	case 's':
		*client = Shockwave
	default:
		return false
	}
	return true
}
