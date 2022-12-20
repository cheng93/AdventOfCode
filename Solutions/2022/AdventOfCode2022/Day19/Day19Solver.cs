namespace AdventOfCode2022.Day19;

public static class Day19Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
        => input
            .Select(x => new Day19Blueprint(x))
            .Select((x, i) => (i + 1) * x.GetGeodes(24))
            .Sum();

    public static int PuzzleTwo(IEnumerable<string> input)
        => input
            .Select(x => new Day19Blueprint(x))
            .Take(3)
            .Select(x => x.GetGeodes(32))
            .Aggregate((agg, cur) => agg *= cur);
}