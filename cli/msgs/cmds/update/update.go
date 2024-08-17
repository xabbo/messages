package update

import (
	"errors"
	"fmt"
	"io/fs"
	"os"
	"strings"

	"github.com/fatih/color"
	"github.com/spf13/cobra"

	"xabbo.b7c.io/messages/cli/internal/messages"
	"xabbo.b7c.io/messages/cli/internal/sulek"
	root "xabbo.b7c.io/messages/cli/msgs/cmds"
)

var updateCmd = &cobra.Command{
	Use:   `update [filename] (default "messages.ini")`,
	Short: "Updates the message map with messages from the Sulek API.",
	Args:  cobra.MaximumNArgs(1),
	RunE:  run,
}

func init() {
	updateCmd.DisableFlagsInUseLine = true
	root.AddCommand(updateCmd)
}

func run(cmd *cobra.Command, args []string) (err error) {
	cmd.SilenceUsage = true

	colorAdd := color.New(color.FgGreen)
	colorMerge := color.New(color.FgCyan)

	var msgs messages.MessageMap

	fileName := "messages.ini"
	if len(args) > 0 {
		fileName = args[0]
	}

	_, err = os.Stat(fileName)
	if err != nil {
		if !errors.Is(err, fs.ErrNotExist) {
			return err
		}
		msgs = messages.NewMessageMap()
		err = nil
	} else {
		msgs, err = messages.LoadMapFile(fileName)
		if err != nil {
			return
		}
	}

	sulekClientMsgs := map[messages.Client]sulek.Messages{}

	for _, client := range messages.Clients {
		if client == messages.Unity {
			continue
		}

		fmt.Printf("Fetching latest %s release... ", client)

		variant := strings.ToLower(client.String()) + "-windows"

		var releases []sulek.Release
		releases, err = sulek.FetchReleases(variant)
		if err != nil {
			return
		}

		if len(releases) == 0 {
			return fmt.Errorf("no releases found")
		}

		release := releases[0]
		fmt.Println(release.Version)

		fmt.Printf("Fetching %s messages... ", client)
		var msgs sulek.Messages
		msgs, err = sulek.FetchMessages(variant, release.Version)
		if err != nil {
			return
		}

		if client != messages.Shockwave {
			for i, msg := range msgs.Incoming {
				msgs.Incoming[i].Name = messages.CleanName(messages.In, msg.Name)
			}
			for i, msg := range msgs.Outgoing {
				msgs.Outgoing[i].Name = messages.CleanName(messages.Out, msg.Name)
			}
		}

		sulekClientMsgs[client] = msgs
		fmt.Printf("%d incoming / %d outgoing messages\n", len(msgs.Incoming), len(msgs.Outgoing))
	}

	// merge
	for client, sulekMsgs := range sulekClientMsgs {
		for _, dir := range messages.Directions {
			sulekMsgsList := getSulekMessagesDir(sulekMsgs, dir)
			for _, sulekMsg := range sulekMsgsList {
				entry := &messages.MsgMapEntry{}
				entry.Set(client, sulekMsg.Name)
				op := msgs.AddOrMerge(dir, entry)
				switch op.Result {
				case messages.MergeConflict:
					err = fmt.Errorf("merge conflict on %s message: %s -> %s", op.Conflict, op.Src, op.Dst)
					return
				case messages.MergeOk:
					colorMerge.Fprintf(cmd.OutOrStdout(), "[ merged ] %s -> %s -> %s\n", op.Src, &op.Prev, op.Dst)
				case messages.MergeAdd:
					colorAdd.Fprintf(cmd.OutOrStdout(), "[  added ] %s\n", op.Dst)
				}
			}
		}
	}

	f, err := os.OpenFile(fileName, os.O_RDWR|os.O_CREATE|os.O_TRUNC, 0644)
	if err != nil {
		return
	}
	defer f.Close()

	msgs.Write(f)
	return
}

func getSulekMessagesDir(sulekMsgs sulek.Messages, dir messages.Direction) []sulek.Message {
	switch dir {
	case messages.In:
		return sulekMsgs.Incoming
	case messages.Out:
		return sulekMsgs.Outgoing
	default:
		panic("invalid direction")
	}
}
