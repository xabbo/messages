package cmds

import "github.com/spf13/cobra"

var rootCmd = &cobra.Command{
	Use:           "messages",
	Short:         "Manages messages between multiple clients.",
	SilenceErrors: true,
	CompletionOptions: cobra.CompletionOptions{
		HiddenDefaultCmd: true,
	},
}

func AddCommand(cmd *cobra.Command) {
	rootCmd.AddCommand(cmd)
}

func Execute() error {
	return rootCmd.Execute()
}
