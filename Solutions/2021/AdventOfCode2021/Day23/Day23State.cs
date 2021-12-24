namespace AdventOfCode2021.Day23;

public class Day23State
{
    public Day23State(char?[] hallway, Day23Room[] rooms)
    {
        Hallway = hallway;
        Rooms = rooms;
    }

    public char?[] Hallway { get; }
    public Day23Room[] Rooms { get; }
    public bool Sorted => Rooms.All(x => x.Sorted);

    public IEnumerable<(Day23State State, int Energy)> GetNextStates()
    {
        for (var i = 0; i < Hallway.Length; i++)
        {
            if (!Hallway[i].HasValue)
            {
                continue;
            }
            var c = Hallway[i]!.Value;
            var mapped = _map[c];
            var room = Rooms[mapped];
            if (room.CanEnter(c, out var inDistance))
            {
                var roomHallwayIndex = _roomHallwayIndices[room.Id];
                if (!Blocked(i, roomHallwayIndex))
                {
                    var totalDistance = Math.Abs(i - roomHallwayIndex) + inDistance;
                    var energy = Weighted(c, totalDistance);

                    var state = this.Clone();
                    state.Hallway[i] = null;
                    state.Rooms[mapped].Enter(c);
                    yield return (state, energy);
                    yield break;
                }
            }
        }

        for (var i = 0; i < Rooms.Length; i++)
        {
            var room = Rooms[i];
            if (room.CanLeave(out var c, out var outDistance))
            {
                var roomHallwayIndex = _roomHallwayIndices[room.Id];
                var mapped = _map[c.Value];
                if (i != mapped)
                {
                    var target = Rooms[mapped];
                    if (target.CanEnter(c.Value, out int inDistance))
                    {
                        var targetIndex = _roomHallwayIndices[target.Id];

                        if (!Blocked(roomHallwayIndex, targetIndex))
                        {
                            var totalDistance = Math.Abs(roomHallwayIndex - targetIndex) + outDistance + inDistance;
                            var energy = Weighted(c.Value, totalDistance);

                            var state = this.Clone();
                            state.Rooms[i].Leave();
                            state.Rooms[mapped].Enter(c.Value);
                            yield return (state, energy);
                            yield break;
                        }
                    }
                }

                foreach (var j in new[] { 0, 1, 3, 5, 7, 9, 10 })
                {
                    if (!Blocked(roomHallwayIndex, j))
                    {
                        var totalDistance = Math.Abs(roomHallwayIndex - j) + outDistance;
                        var energy = Weighted(c.Value, totalDistance);

                        var state = this.Clone();
                        state.Hallway[j] = c;
                        state.Rooms[i].Leave();
                        yield return (state, energy);
                    }
                }
            }
        }

        int Weighted(char c, int distance) => distance * _multiplier[c];
    }

    public Day23State Clone()
    {
        return new Day23State(
            Hallway.ToArray(),
            Rooms.Select(x => x with { }).ToArray());
    }

    public override string ToString()
    {
        var s = string.Join(".", Hallway.Select(x => x ?? '.'));
        foreach (var room in Rooms)
        {
            s += $"|{room}";
        }

        return s;
    }

    private bool Blocked(int source, int target)
    {
        var adjTarget = target + 1;
        var path = source <= target
            ? Hallway[(source + 1)..adjTarget]
            : Hallway[adjTarget..source];

        return path.Any(x => x.HasValue);
    }

    /*
    example:
    #############
    #...........#
    ###B#C#B#D###
      #A#D#C#A#
      #########
    */
    public static Day23State Create(string input)
    {
        var lines = input.Split(Environment.NewLine)[2..^1];

        var hallway = new char?[11];

        var rooms = "ABCD"
            .Select((x, i) =>
            {
                var initial = string.Empty;
                for (var j = 0; j < lines.Length; j++)
                {
                    initial += lines[j].Trim().Split("#", StringSplitOptions.RemoveEmptyEntries)[i][0];
                }
                return new Day23Room(x, lines.Length, initial);
            })
            .ToArray();

        return new Day23State(hallway, rooms);
    }

    private static Dictionary<char, int> _multiplier
        = new()
        {
            { 'A', 1 },
            { 'B', 10 },
            { 'C', 100 },
            { 'D', 1000 }
        };

    private static Dictionary<char, int> _roomHallwayIndices
        = new()
        {
            { 'A', 2 },
            { 'B', 4 },
            { 'C', 6 },
            { 'D', 8 }
        };

    private static Dictionary<char, int> _map
        = new()
        {
            { 'A', 0 },
            { 'B', 1 },
            { 'C', 2 },
            { 'D', 3 }
        };
}