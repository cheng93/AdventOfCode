namespace AdventOfCode2023.Day09;

public static class Day09Solver
{
    public static long PuzzleOne(string input)
        => input
            .Split(Environment.NewLine)
            .Select(x => new Day09History(x).GetNext())
            .Sum();

    public static long PuzzleTwo(string input)
        => input
            .Split(Environment.NewLine)
            .Select(x => new Day09History(x).GetPrevious())
            .Sum();
}