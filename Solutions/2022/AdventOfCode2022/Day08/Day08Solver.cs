namespace AdventOfCode2022.Day08;

using MoreLinq;

public static class Day08Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var lines = input.ToArray();
        var grid = GetGrid(lines);

        var max = (X: lines[0].Length, Y: lines.Length);

        var count = 0;
        for (var x = 0; x < max.X; x++)
        {
            for (var y = 0; y < max.Y; y++)
            {
                var tree = grid[x][y];

                var directions = new[]
                {
                    Enumerable.Range(0, x).Select(n => grid[n][y]),
                    Enumerable.Range(0, y).Select(n => grid[x][n]),
                    Enumerable.Range(x + 1, max.X - x - 1).Select(n => grid[n][y]),
                    Enumerable.Range(y + 1, max.Y - y - 1).Select(n => grid[x][n])
                };

                if (directions.Any(IsVisible))
                {
                    count++;
                }

                bool IsVisible(IEnumerable<int> trees) => trees.All(n => n < tree);
            }
        }

        return count;
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var lines = input.ToArray();
        var grid = GetGrid(lines);

        var max = (X: lines[0].Length, Y: lines.Length);

        var score = int.MinValue;
        for (var x = 0; x < max.X; x++)
        {
            for (var y = 0; y < max.Y; y++)
            {
                var tree = grid[x][y];

                var directions = new[]
                {
                    Enumerable.Range(0, x).Select(n => grid[n][y]).Reverse(),
                    Enumerable.Range(0, y).Select(n => grid[x][n]).Reverse(),
                    Enumerable.Range(x + 1, max.X - x - 1).Select(n => grid[n][y]),
                    Enumerable.Range(y + 1, max.Y - y - 1).Select(n => grid[x][n])
                };

                score = Math.Max(score, directions.Select(GetViewingDistance).Aggregate((agg, cur) => agg * cur));

                int GetViewingDistance(IEnumerable<int> trees) => trees.TakeUntil(n => n >= tree).Count();
            }
        }

        return score;
    }

    private static int[][] GetGrid(string[] lines)
        => lines
            .Select(line => line.Select(x => int.Parse(x.ToString())).ToArray())
            .ToArray();
}