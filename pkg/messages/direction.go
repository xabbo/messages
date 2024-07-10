package messages

// Direction is a bit field representing incoming or outgoing directions.
type Direction int

const (
	In Direction = 1 << iota
	Out
)

// Directions contains the In and Out directions.
var Directions = []Direction{In, Out}

// String returns "incoming", "outgoing", "both" or "none".
func (dir Direction) String() string {
	switch dir {
	case In:
		return "incoming"
	case Out:
		return "outgoing"
	case In | Out:
		return "both"
	default:
		return "none"
	}
}

// Short returns "in", "out", "both" or "none".
func (dir Direction) Short() string {
	switch dir {
	case In:
		return "in"
	case Out:
		return "out"
	case In | Out:
		return "both"
	default:
		return "unknown"
	}
}
