#!/bin/bash

# Generates C# sources from the Sulek API.

fatal() { printf "\x1b[31mError! %s\x1b[0m" "$@" >&2 && exit 1; }

get() {
    curl -qs --fail-with-body -A "xabbo.b7c.io/messages" "$1"
}

output() {
    client="$1"
    dir="$2"
    version="$3"

    case $dir in
        in) direction=incoming ;;
        out) direction=outgoing ;;
    esac

    # identifiers=$(jq -r '.messages.'$direction'[] | "    public static readonly Identifier \(.name) = _();"' | sort) || fatal
    identifiers=$( while read name; do echo "    public static readonly Identifier ${name} = _();"; done )
    generated="Generated for the ${client^} client version ${version}"

    cat << EOF
// ${generated} from the Sulek API (https://sulek.dev/).

using System.Runtime.CompilerServices;

namespace Xabbo.Messages.${client^};

/// <summary>
/// ${generated} from the <a href="https://sulek.dev/">Sulek API</a>.
/// </summary>
public static class ${dir^} {
    private static Identifier _([CallerMemberName]string? name = null)
    {
        ArgumentNullException.ThrowIfNull(name, nameof(name));
        return new Identifier(ClientType.${client^}, Direction.${dir^}, name);
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

${identifiers}

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
EOF

    echo "Wrote $(echo "$identifiers" | wc -l) $direction identifiers" >&2
}

generate() {
    client="$1"
    variant="${client}-windows"

    echo "Fetching latest version for ${variant}..."

    releases=$(get "https://api.sulek.dev/releases?variant=$variant") || fatal "failed to get releases"
    release=$(echo "$releases" | jq -r '.[0].version') || fatal "failed to find latest release version"

    echo "Fetching messages for release $release..."
    messages=$(get "https://api.sulek.dev/releases/$variant/$release/messages") || fatal "failed to get messages"

    mkdir -p "${client^}"
    for dir in {in,out}; do
        echo "$messages" | go run ../../cli/msgs list -x -d $dir | output "$client" "$dir" "$release" > "${client^}/${dir^}.cs"
    done
}

generate flash
generate shockwave