namespace AdventOfCode2022.Day01;

public static class Day01Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        return input
            .Select(x => x.Split(Environment.NewLine).Select(int.Parse).Sum())
            .Max();
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        return input
            .Select(x => x.Split(Environment.NewLine).Select(int.Parse).Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
    }
}