namespace AdventOfCode2022.Day14;

public static class Day14Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
        => Solve(input).TakeWhile(x => !x.Overflow).Count();

    public static int PuzzleTwo(IEnumerable<string> input)
        => Solve(input).Count();

    private static IEnumerable<(int X, int Y, bool Overflow)> Solve(IEnumerable<string> input)
    {
        var grid = new Dictionary<int, HashSet<int>>();
        var rockStructures = input
            .Select(x => new Day14RockStructure(x))
            .ToArray();

        var maxY = int.MinValue;
        foreach (var rockStructure in rockStructures)
        {
            foreach (var point in rockStructure.GetPath())
            {
                if (!grid.TryGetValue(point.X, out var y))
                {
                    y = new HashSet<int>();
                    grid[point.X] = y;
                }

                y.Add(point.Y);
                maxY = Math.Max(maxY, point.Y + 2);
            }
        }

        foreach (var y in grid.Values)
        {
            y.Add(maxY);
        }

        var overflow = false;
        var sand = (X: 500, Y: 0);
        var directions = new (int X, int Y)[]
        {
                (0, 1),
                (-1, 1),
                (1, 1)
        };

        while (!grid[500].Contains(0))
        {
            var atRest = true;
            foreach (var direction in directions)
            {
                var next = (X: sand.X + direction.X, Y: sand.Y + direction.Y);

                if (!grid.TryGetValue(next.X, out var y))
                {
                    y = new HashSet<int>();
                    y.Add(maxY);
                    overflow = true;
                    grid[next.X] = y;
                }

                if (!y.Contains(next.Y))
                {
                    atRest = false;
                    sand = next;
                    break;
                }
            }

            if (atRest)
            {
                yield return (sand.X, sand.Y, overflow);
                grid[sand.X].Add(sand.Y);
                sand = (500, 0);
            }
        }
    }
}