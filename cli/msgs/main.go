package main

import (
	"os"

	"github.com/fatih/color"

	root "xabbo.b7c.io/messages/cli/msgs/cmds"
	_ "xabbo.b7c.io/messages/cli/msgs/cmds/find"
	_ "xabbo.b7c.io/messages/cli/msgs/cmds/format"
	_ "xabbo.b7c.io/messages/cli/msgs/cmds/list"
	_ "xabbo.b7c.io/messages/cli/msgs/cmds/update"
)

func main() {
	if err := root.Execute(); err != nil {
		color.New(color.FgRed).Fprintf(os.Stderr, "Error: %s\n", err)
		os.Exit(1)
	}
}
