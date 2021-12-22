namespace AdventOfCode2021.Day19;

public class Day19Scanner
{
    private Day19Scanner(int id, (int X, int Y, int Z)[] beacons, (int X, int Y, int Z)? location = null)
    {
        Id = id;
        Beacons = beacons;
        Location = location ?? (0, 0, 0);

        for (var i = 0; i < Beacons.Length - 1; i++)
        {
            for (var j = i + 1; j < Beacons.Length; j++)
            {
                var a = Beacons[i];
                var b = Beacons[j];
                Deltas.Add(
                    (a.X - b.X, a.Y - b.Y, a.Z - b.Z),
                    (a, b));
            }
        }
    }

    public int Id { get; }

    public (int X, int Y, int Z)[] Beacons { get; }

    public (int X, int Y, int Z) Location { get; }

    public Dictionary<(int X, int Y, int Z), ((int X, int Y, int Z) A, (int X, int Y, int Z) B)> Deltas { get; } = new();

    public Day19Scanner Transform(Func<(int X, int Y, int Z), (int X, int Y, int Z)> func)
    {
        if (Beacons[0] == func(Beacons[0]))
        {
            return this;
        }

        var beacons = Beacons.Select(func).ToArray();

        return new Day19Scanner(Id, beacons, this.Location);
    }

    public Day19Scanner At((int X, int Y, int Z) location)
    {
        (int X, int Y, int Z) Translate((int X, int Y, int Z) p)
            => (p.X + location.X, p.Y + location.Y, p.Z + location.Z);

        var beacons = Beacons.Select(Translate).ToArray();

        return new Day19Scanner(Id, beacons, location);
    }


    /*
    example:
    --- scanner 0 ---
    -1,-1,1
    -2,-2,2
    -3,-3,3
    -2,-3,1
    5,6,-4
    8,0,7
    */
    public static Day19Scanner Create(string input)
    {
        var lines = input.Split(Environment.NewLine).ToArray();

        var id = int.Parse(lines[0].Split(" ")[2]);

        var beacons = lines
            .Skip(1)
            .Select(x =>
            {
                var splits = x
                    .Split(",")
                    .Select(int.Parse)
                    .ToArray();

                return (splits[0], splits[1], splits[2]);
            })
            .ToArray();

        return new Day19Scanner(id, beacons);
    }
}

public static class Day19ScannerExtensions
{
    public static IEnumerable<(int X, int Y, int Z)> MatchingDeltas(this Day19Scanner scanner, Day19Scanner other)
    {
        return scanner.Deltas.Keys.Intersect(other.Deltas.Keys);
    }
}