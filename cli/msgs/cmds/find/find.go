package find

import (
	"fmt"
	"regexp"
	"strings"

	"github.com/spf13/cobra"
	"golang.org/x/text/cases"
	"golang.org/x/text/language"

	"xabbo.b7c.io/messages/cli/internal/messages"
	root "xabbo.b7c.io/messages/cli/msgs/cmds"
)

var findCommand = &cobra.Command{
	Use:   `find [name]`,
	Short: "Finds messages in a message map file",
	Args:  cobra.ExactArgs(1),
	RunE:  run,
}

var opts struct {
	filename        string
	incoming        bool
	outgoing        bool
	clients         string
	regex           bool
	caseInsensitive bool
}

func init() {
	root.AddCommand(findCommand)

	f := findCommand.Flags()
	f.StringVarP(&opts.filename, "file", "f", "messages.ini", "The message map file path")
	f.BoolVarP(&opts.incoming, "in", "i", false, "Find incoming messages")
	f.BoolVarP(&opts.outgoing, "out", "o", false, "Find outgoing messages")
	f.StringVarP(&opts.clients, "clients", "c", "ufs", "Client messages to search")
	f.BoolVarP(&opts.regex, "regex", "r", false, "Use regular expression")
	f.BoolVarP(&opts.caseInsensitive, "case-insensitive", "I", false, "Use case insensitive matching")
}

func run(cmd *cobra.Command, args []string) (err error) {
	cmd.SilenceUsage = true

	var rgxMatch *regexp.Regexp
	if opts.regex {
		pattern := args[0]
		if !opts.caseInsensitive {
			pattern = "(?i)" + pattern
		}
		rgxMatch, err = regexp.Compile(pattern)
		if err != nil {
			return err
		}
	}
	searchText := args[0]
	if !opts.caseInsensitive {
		searchText = strings.ToLower(searchText)
	}

	msgs, err := messages.LoadMapFile(opts.filename)
	if err != nil {
		return
	}

	var targetClients messages.Client
	for _, c := range opts.clients {
		var client messages.Client
		if !client.FromRune(c) {
			return fmt.Errorf("invalid client specified: %q", c)
		}
		targetClients |= client
	}
	if targetClients == 0 {
		return fmt.Errorf("no clients specified")
	}

	directions := []messages.Direction{}
	if !opts.incoming && !opts.outgoing {
		directions = append(directions, messages.In, messages.Out)
	} else {
		if opts.incoming {
			directions = append(directions, messages.In)
		}
		if opts.outgoing {
			directions = append(directions, messages.Out)
		}
	}
	if len(directions) == 0 {
		return fmt.Errorf("no direction specified")
	}

	firstOut := true
	for _, dir := range directions {
		firstDir := true
		for _, entry := range msgs.All(dir) {
			match := false
			for _, client := range messages.Clients {
				if (client & targetClients) == 0 {
					continue
				}
				if rgxMatch != nil {
					if rgxMatch.MatchString(entry.Get(client)) {
						match = true
						break
					}
				} else {
					name := entry.Get(client)
					if !opts.caseInsensitive {
						name = strings.ToLower(name)
					}
					if strings.Contains(name, searchText) {
						match = true
						break
					}
				}
			}
			if match {
				if firstDir {
					if !firstOut {
						cmd.Println()
					}
					cmd.Printf("[%s]\n", cases.Title(language.English, cases.Compact).String(dir.String()))
					firstDir = false
					firstOut = false
				}
				cmd.Println(entry)
			}
		}
	}

	return
}
