namespace AdventOfCode2023.Day11;

using Coord = (long X, long Y);

public static class Day11Solver
{
    public static long PuzzleOne(string input) => Solve(input, 2);

    public static long PuzzleTwo(string input, long factor = 1000000L) => Solve(input, factor);

    private static long Solve(string input, long factor)
    {
        var image = new Day11Image(input);
        var expanded = image.Expand(factor).ToList();

        var sum = 0L;
        for (var i = 0; i < expanded.Count; i++)
        {
            for (var j = i + 1; j < expanded.Count; j++)
            {
                sum += ManhattanDistance(expanded[i], expanded[j]);
            }
        }

        return sum;
    }

    private static long ManhattanDistance(Coord a, Coord b)
        => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
}