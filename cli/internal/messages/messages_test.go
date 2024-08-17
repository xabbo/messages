package messages

import (
	"bytes"
	"os"
	"strings"
	"testing"
)

func TestFormat(t *testing.T) {
	testBytes, err := os.ReadFile("testdata/tests.ini")
	if err != nil {
		t.Fatal(err)
	}
	tests := strings.Split(string(testBytes), "-----INPUT-----")
	for _, test := range tests {
		split := strings.Split(test, "-----OUTPUT-----")
		if len(split) < 2 {
			continue
		}
		input := strings.TrimSpace(split[0])
		expected := strings.ReplaceAll(strings.TrimSpace(split[1]), "\r\n", "\n")
		r := strings.NewReader(input)
		msgs, err := LoadMap(r)
		if err != nil {
			if expected == "ERROR" {
				continue
			}
			t.Fatal(err)
		} else if expected == "ERROR" {
			t.Fatal("expected error did not occur")
		}
		w := &bytes.Buffer{}
		msgs.Write(w)
		actual := strings.TrimSpace(w.String())
		if actual != expected {
			t.Fatalf("%q != %q", expected, actual)
		}
	}
}
