![NuGet Version](https://img.shields.io/nuget/v/Xabbo.Messages?style=for-the-badge)
![NuGet Downloads](https://img.shields.io/nuget/dt/Xabbo.Messages?style=for-the-badge)

# xabbo/messages

Provides a mapping for message names between different Habbo clients.

The `cli` directory contains the command-line tool used to update and format the message map file.

## Specification

All entries must come under an `[Incoming]` or `[Outgoing]` section.

Entries must be a whitespace separated list of `clients:messageName` fields.

`clients` must be a string containing `u`, `f`, and/or `s` to indicate the message name belongs to the Unity, Flash and/or Shockwave clients.\
`clients` must be lowercase, while `messageName` is case insensitive.\
`messageName` may be blank, represented by a single dash `-` to indicate that the message does not exist in the specified client(s). Entries must specify at least one valid message identifier - it is invalid for only a blank identifier to stand alone.

Multiple fields may appear on the same line to indicate that they are equivalent across those clients.

Some examples of valid message map entries are:
- `ufs:Chat` - the `Chat` message is equivalent across all clients
- `uf:Whisper s:CHAT_2` - the Unity/Flash `Chat` message is equivalent to the Shockwave `CHAT_2` message
- `u:UsersInRoom fs:Users` - the Unity `UsersInRoom` message is equivalent to the Flash/Shockwave `Users` message
- `u:UserLoggedOut f:UserRemove s:LOGOUT` - the messages have different names but are equivalent across the three clients
- `u:Token fs:-` - the Unity `Token` message does not exist in the Flash and Shockwave clients
- `u:AntiSpamTriggered` - the Unity `AntiSpamTriggered` message either does not exist in the other clients or the mapping is currently unknown

End-of-line comments may be associated with an entry by using a semicolon to begin the comment after the fields.

### Merging

If messages with the same name exist in different entries, they are merged. For example:
```
u:Whisper
f:Whisper s:CHAT_2
```
should result in:
```
uf:Whisper s:CHAT_2
```

### Merge conflicts

Attempting to merge multiple entries into one entry containing different message names for the same client is invalid. As an example:
```
u:ActiveObjects f:Objects
s:ActiveObjects
s:Objects
```
These three entries will attempt to merge on `us:ActiveObjects` and `fs:Objects`, however they cannot be merged as there is a conflict between `s:ActiveObjects` and `s:Objects`.

The problem with this is that `ActiveObjects` on Unity and Shockwave is equivalent to `Objects` on Flash, but the Shockwave `Objects` message is unrelated and must therefore be kept separate.

To deal with this, a field can be prefixed with a `!` (no merge indicator) to indicate that the client message specified by the field cannot be merged into the current entry.

Thus, the following entries:
```ini
u:ActiveObjects f:Objects !s:Objects ; do not merge s:Objects into this entry
s:ActiveObjects
s:Objects
```
will successfully merge into the following after running `messages fmt`:
```ini
us:ActiveObjects f:Objects !s:Objects ; do not merge s:Objects into this entry
s:Objects
```

It is invalid for a no merge indicator to be specified on a blank identifier: `!f:-`.
