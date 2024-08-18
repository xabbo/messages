package list

import (
	"fmt"
	"slices"
	"strings"

	"github.com/spf13/cobra"

	"xabbo.b7c.io/messages/cli/internal/messages"
	"xabbo.b7c.io/messages/cli/internal/sulek"
	root "xabbo.b7c.io/messages/cli/msgs/cmds"
)

var listCmd = &cobra.Command{
	Use:                   "list <direction> <variant> [-r release]",
	DisableFlagsInUseLine: true,
	Args:                  cobra.ExactArgs(2),
	RunE:                  run,
}

var opts struct {
	release string
}

func init() {
	root.AddCommand(listCmd)

	listCmd.Flags().StringVarP(&opts.release, "release", "r", "", "Release to fetch messages for (defaults to latest release)")
}

func run(cmd *cobra.Command, args []string) (err error) {
	cmd.SilenceUsage = true

	var direction messages.Direction
	switch args[0] {
	case "in":
		direction = messages.In
	case "out":
		direction = messages.Out
	default:
		return fmt.Errorf("invalid direction: %s", args[0])
	}

	variant := args[1]
	version := opts.release

	if version == "" {
		cmd.PrintErrf("Fetching latest release for %s...\n", variant)
		releases, err := sulek.FetchReleases(variant)
		if err != nil {
			return err
		}
		if len(releases) == 0 {
			return fmt.Errorf("no releases found")
		}
		version = releases[0].Version
	}

	cmd.PrintErrf("Fetching messages for %s version %s\n", variant, version)
	allMsgs, err := sulek.FetchMessages(variant, version)
	if err != nil {
		return
	}

	var msgs []sulek.Message
	if direction == messages.In {
		msgs = allMsgs.Incoming
	} else {
		msgs = allMsgs.Outgoing
	}

	messageNames := []string{}
	for _, msg := range msgs {
		name := msg.Name
		if !strings.Contains(variant, "shockwave") {
			name = messages.CleanName(direction, name)
		}
		messageNames = append(messageNames, name)
	}

	slices.Sort(messageNames)
	for _, name := range messageNames {
		cmd.Println(name)
	}
	return
}
