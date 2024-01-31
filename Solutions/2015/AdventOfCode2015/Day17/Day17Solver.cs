namespace AdventOfCode2015.Day17;

using MoreLinq;

public static class Day17Solver
{
    public static int PuzzleOne(string input, int liters = 150)
    {
        var containers = input
            .Split(Environment.NewLine)
            .Select(int.Parse)
            .ToArray();

        return containers
            .Subsets()
            .Count(x => x.Sum() == liters);
    }

    public static int PuzzleTwo(string input, int liters = 150)
    {
        var containers = input
            .Split(Environment.NewLine)
            .Select(int.Parse)
            .ToArray();

        return containers
            .Subsets()
            .Where(x => x.Sum() == liters)
            .GroupBy(x => x.Count)
            .OrderBy(x => x.Key)
            .First()
            .Count();
    }
}