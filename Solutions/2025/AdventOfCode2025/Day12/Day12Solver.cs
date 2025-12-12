namespace AdventOfCode2025.Day12;

public static class Day12Solver
{
    public static int PuzzleOne(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var presents = splits
            .SkipLast(1)
            .Select(x => new Day12Present(x))
            .ToArray();
        var regions = splits.Last()
            .Split(Environment.NewLine)
            .Select(x => new Day12Region(x))
            .ToArray();

        return regions.Count(r => r.Height * r.Width >= r.Quantities.Sum() * 9);
    }

    public static long PuzzleTwo(string input)
    {
        return 0;
    }
}