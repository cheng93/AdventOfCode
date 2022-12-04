namespace AdventOfCode2022.Day04;

public static class Day04Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        return input
            .Select(x => new Day04Pair(x))
            .Count(x => x.First.Contains(x.Last) || x.Last.Contains(x.First));
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        return input
             .Select(x => new Day04Pair(x))
             .Count(x => x.First.Intersects(x.Last));
    }
}