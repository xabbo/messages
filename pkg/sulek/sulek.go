package sulek

import (
	"encoding/json"
	"fmt"
	"net/http"
	"net/url"
)

type Release struct {
	Id          int     `json:"id"`
	Variant     int     `json:"variant"`
	VariantPath string  `json:"variantPath"`
	Version     string  `json:"version"`
	Size        int     `json:"size"`
	Packets     Packets `json:"packets"`
}

type Packets struct {
	Count int `json:"count"`
	Total int `json:"total"`
}

type MessagesContainer struct {
	Messages Messages `json:"messages"`
}

type Messages struct {
	Incoming []Message `json:"incoming"`
	Outgoing []Message `json:"outgoing"`
}

type Message struct {
	Id        int    `json:"id"`
	Name      string `json:"name"`
	Namespace string `json:"asNamespace"`
	Class     string `json:"asClass"`
	Confident bool   `json:"confident"`
}

func FetchReleases(variant string) (releases []Release, err error) {
	var res *http.Response
	res, err = http.Get(fmt.Sprintf("https://api.sulek.dev/releases?variant=%s", url.QueryEscape(variant)))
	if err != nil {
		return
	}

	if res.StatusCode != 200 {
		err = fmt.Errorf("sulek: %s", res.Status)
		return
	}

	err = json.NewDecoder(res.Body).Decode(&releases)
	return
}

func FetchMessages(variant, version string) (messages Messages, err error) {
	res, err := http.Get("https://api.sulek.dev/releases/" + variant + "/" + version + "/messages")
	if err != nil {
		return
	}

	if res.StatusCode != 200 {
		err = fmt.Errorf("sulek: %s", res.Status)
		return
	}

	container := struct {
		Messages Messages `json:"messages"`
	}{}

	err = json.NewDecoder(res.Body).Decode(&container)
	if err == nil {
		messages = container.Messages
	}
	return
}
