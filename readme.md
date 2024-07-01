# xabbo/messages

Provides a mapping for message names between different Habbo clients.

## Specification

All entries must come under an `[Incoming]` or `[Outgoing]` section.

Entries must be a whitespace separated list of `clients:messageName` fields.

`clients` must be a string containing `u`, `f`, and/or `s` to indicate the message name belongs to the Unity, Flash and/or Shockwave clients. `clients` must be lowercase, while `messageName` is case insensitive.

Multiple fields may appear on the same line to indicate that they are equivalent across those clients. Some examples are:
- `ufs:Chat` - the `Chat` message is equivalent across all clients
- `uf:Whisper s:CHAT_2` - the Unity/Flash `Chat` message is equivalent to the Shockwave `CHAT_2` message
- `u:UsersInRoom fs:Users` - the Unity `UsersInRoom` message is equivalent to the Flash/Shockwave `Users` message
- `u:UserLoggedOut f:UserRemove s:LOGOUT` - the messages have different names but are equivalent across the three clients
- `u:Token` - the Unity `Token` message either does not exist in the other clients, or the mapping is currently unknown

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

To deal with this, a field can be prefixed with a `!` (no merge) operator to indicate that the client message specified by the field cannot be merged into the current entry.

Thus, the following entries:
```ini
u:ActiveObjects f:Objects !s:Objects ; do not merge s:Objects into this entry
s:ActiveObjects
s:Objects
```
will successfully merge into the following when running `messages fmt`:
```ini
us:ActiveObjects f:Objects !s:Objects ; do not merge s:Objects into this entry
s:Objects
```