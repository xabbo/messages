package list

import (
	"encoding/json"
	"fmt"
	"slices"

	"github.com/spf13/cobra"

	"xabbo.b7c.io/messages/cli/internal/messages"
	"xabbo.b7c.io/messages/cli/internal/sulek"
	root "xabbo.b7c.io/messages/cli/msgs/cmds"
)

var listCmd = &cobra.Command{
	Use:  "list",
	Args: cobra.NoArgs,
	RunE: run,
}

var opts struct {
	release   string
	variant   string
	direction string
	extract   bool
	prefix    bool
	clean     bool
}

func init() {
	root.AddCommand(listCmd)

	listCmd.Flags().StringVarP(&opts.direction, "direction", "d", "both", "Direction of messages to fetch (in/out/both)")
	listCmd.Flags().StringVarP(&opts.variant, "variant", "v", "", "Variant to fetch messages for")
	listCmd.Flags().StringVarP(&opts.release, "release", "r", "", "Release to fetch messages for (defaults to latest release)")
	listCmd.Flags().BoolVarP(&opts.extract, "extract", "x", false, "Extract message names from JSON input")
	listCmd.Flags().BoolVar(&opts.prefix, "prefix", false, "Prefix message names with their direction")
	listCmd.Flags().BoolVar(&opts.clean, "clean", true, "Clean message names by removing the (Message)Event/Composer suffix")
}

func run(cmd *cobra.Command, args []string) (err error) {
	cmd.SilenceUsage = true

	var directions []messages.Direction
	if opts.direction == "" {
		return fmt.Errorf("no direction specified")
	}
	switch opts.direction {
	case "in":
		directions = []messages.Direction{messages.In}
	case "out":
		directions = []messages.Direction{messages.Out}
	case "both":
		directions = []messages.Direction{messages.In, messages.Out}
	default:
		return fmt.Errorf("invalid direction: %s", opts.direction)
	}

	var sulekMessages sulek.Messages
	if opts.extract {
		var container sulek.MessagesContainer
		err = json.NewDecoder(cmd.InOrStdin()).Decode(&container)
		if err != nil {
			return
		}
		sulekMessages = container.Messages
	} else {
		variant := opts.variant
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
		sulekMessages, err = sulek.FetchMessages(variant, version)
		if err != nil {
			return
		}
	}

	messageNames := []string{}
	for _, dir := range directions {
		var msgs []sulek.Message
		switch dir {
		case messages.In:
			msgs = sulekMessages.Incoming
		case messages.Out:
			msgs = sulekMessages.Outgoing
		default:
			continue
		}

		for _, msg := range msgs {
			name := msg.Name
			if opts.clean {
				name = messages.CleanName(dir, msg.Name)
			}
			if opts.prefix {
				name = dir.Short() + ":" + name
			}
			messageNames = append(messageNames, name)
		}
	}

	slices.Sort(messageNames)
	for _, name := range messageNames {
		cmd.Println(name)
	}

	return
}
