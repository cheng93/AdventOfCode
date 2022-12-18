namespace AdventOfCode2022.Day18;

public static class Day18Solver
{
    public static int PuzzleOne(IEnumerable<string> input) => GetShape(input).Values.Sum();

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var shape = GetShape(input);
        var airPockets = new Dictionary<(int X, int Y, int Z), int>();

        foreach (var cube in shape.Keys)
        {
            for (var i = 0; i < Vectors.Length; i++)
            {
                var vector = Vectors[i];
                var neighbour = (cube.X + vector.X, cube.Y + vector.Y, cube.Z + vector.Z);
                if (!shape.ContainsKey(neighbour))
                {
                    airPockets.TryAdd(neighbour, 0);
                    airPockets[neighbour]++;
                }
            }
        }

        var bounds = new (int Min, int Max)[]
        {
            (shape.Keys.Select(x => x.X).Min(), shape.Keys.Select(x => x.X).Max()),
            (shape.Keys.Select(x => x.Y).Min(), shape.Keys.Select(x => x.Y).Max()),
            (shape.Keys.Select(x => x.Z).Min(), shape.Keys.Select(x => x.Z).Max()),
        };

        var totalAirPocketSurfaceArea = 0;
        var bad = new HashSet<(int X, int Y, int Z)>();
        var totalVisited = new HashSet<(int X, int Y, int Z)>();

        foreach (var airPocket in airPockets.Keys)
        {
            var airPocketSurfaceArea = 0;
            if (totalVisited.Contains(airPocket))
            {
                continue;
            }

            var visited = new HashSet<(int X, int Y, int Z)>();
            var stack = new Stack<(int X, int Y, int Z)>();
            stack.Push(airPocket);
            var isValid = true;

            while (stack.Any())
            {
                var current = stack.Pop();
                if (!isValid)
                {
                    visited.Add(current);
                    continue;
                }

                var values = new[]
                {
                    current.X,
                    current.Y,
                    current.Z
                };

                if (Enumerable.Range(0, 3).Any(x => values[x] < bounds[x].Min || values[x] > bounds[x].Max) || bad.Contains(current))
                {
                    visited.Add(current);
                    isValid = false;
                    continue;
                }

                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    if (airPockets.TryGetValue(current, out var surfaceArea))
                    {
                        airPocketSurfaceArea += surfaceArea;
                    }
                    foreach (var neighbour in GetNeighbours())
                    {
                        stack.Push(neighbour);
                    }

                    IEnumerable<(int X, int Y, int Z)> GetNeighbours()
                        => Vectors
                            .Select(x => (current.X + x.X, current.Y + x.Y, current.Z + x.Z))
                            .Where(x => !visited.Contains(x) && !shape.ContainsKey(x));

                }
            }

            totalVisited.UnionWith(visited);
            if (!isValid)
            {
                bad.UnionWith(visited);
            }
            else
            {
                totalAirPocketSurfaceArea += airPocketSurfaceArea;
            }
        }
        return shape.Values.Sum() - totalAirPocketSurfaceArea;
    }

    private static readonly (int X, int Y, int Z)[] Vectors = new[]
    {
            (1, 0, 0),
            (-1, 0, 0),
            (0, 1, 0),
            (0, -1, 0),
            (0, 0, 1),
            (0, 0, -1),
    };

    private static Dictionary<(int X, int Y, int Z), int> GetShape(IEnumerable<string> input)
    {
        var cubes = input
            .Select(x => x.Split(",").Select(int.Parse).ToArray())
            .Select(x => (X: x[0], Y: x[1], Z: x[2]))
            .Distinct();

        var shape = new Dictionary<(int X, int Y, int Z), int>();

        foreach (var cube in cubes)
        {
            var neighbours = 0;

            for (var i = 0; i < Vectors.Length; i++)
            {
                var vector = Vectors[i];
                var neighbour = (cube.X + vector.X, cube.Y + vector.Y, cube.Z + vector.Z);
                if (shape.ContainsKey(neighbour))
                {
                    shape[neighbour]--;
                    neighbours++;
                }
            }

            shape.Add(cube, 6 - neighbours);
        }

        return shape;
    }
}