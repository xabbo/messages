package main

import (
	"os"

	"github.com/fatih/color"

	"xabbo.b7c.io/messages/cmd/messages"
	_ "xabbo.b7c.io/messages/cmd/messages/format"
	_ "xabbo.b7c.io/messages/cmd/messages/update"
)

func main() {
	if err := messages.Execute(); err != nil {
		color.New(color.FgRed).Fprintf(os.Stderr, "Error: %s\n", err)
		os.Exit(1)
	}
}
