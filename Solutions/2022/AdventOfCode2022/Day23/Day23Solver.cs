namespace AdventOfCode2022.Day23;

public static class Day23Solver
{
    public static int PuzzleOne(string input) => Simulate(input).Skip(9).First();

    public static int PuzzleTwo(string input) => Simulate(input).Count();

    private static IEnumerable<int> Simulate(string input)
    {
        var lines = input.Split(Environment.NewLine).ToArray();

        var positions = new HashSet<(int X, int Y)>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                var character = line[x];
                if (character == '#')
                {
                    positions.Add((x, y));
                }
            }
        }

        var directions = new (int X, int Y)[]
        {
            (-1, -1),
            (0, -1),
            (1,-1),
            (-1,0),
            (1,0),
            (-1,1),
            (0,1),
            (1,1),
        };

        var i = 0;
        while (true)
        {
            var proposed = new Dictionary<(int X, int Y), List<(int X, int Y)>>();
            foreach (var position in positions)
            {
                var newPositions = directions
                    .Select(x => (position.X + x.X, position.Y + x.Y))
                    .ToArray();
                var checks = newPositions
                    .Select(x => !positions.Contains(x))
                    .ToArray();

                if (checks.All(x => x))
                {
                    continue;
                }

                for (var j = 0; j < 4; j++)
                {
                    var mod = (i + j) % 4;
                    if (mod == 0 && checks.Take(3).All(x => x))
                    {
                        var north = newPositions[1];
                        proposed.TryAdd(north, new List<(int X, int Y)>());
                        proposed[north].Add(position);
                        break;
                    }
                    else if (mod == 1 && checks.Skip(5).Take(3).All(x => x))
                    {
                        var south = newPositions[6];
                        proposed.TryAdd(south, new List<(int X, int Y)>());
                        proposed[south].Add(position);
                        break;
                    }
                    else if (mod == 2 && checks.Where((x, i) => directions[i].X == -1).All(x => x))
                    {
                        var west = newPositions[3];
                        proposed.TryAdd(west, new List<(int X, int Y)>());
                        proposed[west].Add(position);
                        break;
                    }
                    else if (mod == 3 && checks.Where((x, i) => directions[i].X == 1).All(x => x))
                    {
                        var east = newPositions[4];
                        proposed.TryAdd(east, new List<(int X, int Y)>());
                        proposed[east].Add(position);
                        break;
                    }
                }
            }

            foreach (var (to, from) in proposed)
            {
                if (from.Count > 1)
                {
                    continue;
                }

                positions.Add(to);
                positions.Remove(from[0]);
            }

            var maxX = positions.Select(x => x.X).Max();
            var maxY = positions.Select(x => x.Y).Max();
            var minX = positions.Select(x => x.X).Min();
            var minY = positions.Select(x => x.Y).Min();

            yield return (1 + maxX - minX) * (1 + maxY - minY) - positions.Count;
            i++;

            if (!proposed.Any())
            {
                yield break;
            }
        }
    }
}