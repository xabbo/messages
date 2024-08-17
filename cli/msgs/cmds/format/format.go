package format

import (
	"github.com/fatih/color"
	"github.com/spf13/cobra"

	"xabbo.b7c.io/messages/cli/internal/messages"
	root "xabbo.b7c.io/messages/cli/msgs/cmds"
)

var formatCmd = &cobra.Command{
	Use:     `format [filename] (default "messages.ini")`,
	Aliases: []string{"fmt"},
	Short:   "Formats a message map and merges entries.",
	Args:    cobra.MaximumNArgs(1),
	RunE:    run,
}

func init() {
	formatCmd.DisableFlagsInUseLine = true
	root.AddCommand(formatCmd)
}

func run(cmd *cobra.Command, args []string) (err error) {
	cmd.SilenceUsage = true

	fileName := "messages.ini"
	if len(args) > 0 {
		fileName = args[0]
	}

	msgs, err := messages.LoadMapFile(fileName)
	if err != nil {
		return
	}

	err = msgs.Save(fileName)
	if err == nil {
		color.New(color.FgGreen).Println("Format OK.")
	}
	return
}
