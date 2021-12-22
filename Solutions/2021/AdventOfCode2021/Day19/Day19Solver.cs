namespace AdventOfCode2021.Day19;

public static class Day19Solver
{
    public static int PuzzleOne(string input)
        => Solve(input)
            .SelectMany(x => x.Beacons)
            .Distinct()
            .Count();

    public static int PuzzleTwo(string input)
    {
        var scanners = Solve(input).ToArray();

        int ManhattanDistance((int X, int Y, int Z) a, (int X, int Y, int Z) b)
            => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) + Math.Abs(a.Z - b.Z);

        var max = int.MinValue;

        for (var i = 0; i < scanners.Length - 1; i++)
        {
            for (var j = i + 1; j < scanners.Length; j++)
            {
                var a = scanners[i].Location;
                var b = scanners[j].Location;
                max = Math.Max(max, ManhattanDistance(a, b));
            }
        }

        return max;
    }

    private static IEnumerable<Day19Scanner> Solve(string input)
    {
        var scanners = input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => Day19Scanner.Create(x))
            .ToArray();

        IEnumerable<Func<(int X, int Y, int Z), (int X, int Y, int Z)>> GetOrientations()
        {
            var initials = new Func<(int X, int Y, int Z), (int X, int Y, int Z)>[]
            {
                p => (p.X, p.Y, p.Z),
                p => (p.Y, p.Z, p.X),
                p => (p.Z, p.Y, -p.X),
                p => (p.Z, p.X, p.Y),
                p => (p.X, p.Z, -p.Y),
                p => (p.Y, p.X, -p.Z),
            };

            (int X, int Y, int Z) Clockwise((int X, int Y, int Z) p)
                => (p.Y, -p.X, p.Z);

            foreach (var initial in initials)
            {
                var func = initial;
                for (var i = 0; i < 4; i++)
                {
                    yield return func;
                    var f = func;
                    func = p => Clockwise(f(p));
                }
            }
        }

        var visited = new HashSet<int>() { 0 };
        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Any())
        {
            var current = scanners[queue.Dequeue()];
            for (var i = 0; i < scanners.Length; i++)
            {
                if (visited.Contains(i))
                {
                    continue;
                }
                var scanner = scanners[i];

                foreach (var orientate in GetOrientations())
                {
                    var orientated = scanner.Transform(orientate);
                    var deltas = current
                        .MatchingDeltas(orientated)
                        .ToArray();

                    var points = deltas
                        .Aggregate(
                            new HashSet<(int X, int Y, int Z)>(),
                            (agg, cur) =>
                            {
                                var delta = orientated.Deltas[cur];
                                agg.Add(delta.A);
                                agg.Add(delta.B);
                                return agg;
                            });

                    if (points.Count >= 12)
                    {
                        var currentPoint = current.Deltas[deltas[0]].A;
                        var orientatedPoint = orientated.Deltas[deltas[0]].A;

                        var location = (
                            X: currentPoint.X - orientatedPoint.X,
                            Y: currentPoint.Y - orientatedPoint.Y,
                            Z: currentPoint.Z - orientatedPoint.Z);

                        scanners[i] = orientated.At(location);
                        queue.Enqueue(i);
                        visited.Add(i);
                        break;
                    }
                }
            }
        }

        return scanners;
    }
}