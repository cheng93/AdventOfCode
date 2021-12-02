namespace AdventOfCode2021.Day02;

public static class Day02Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var aggregate = input
            .Select(x => new Day02Command(x))
            .Aggregate(
                new { Depth = 0, Horizontal = 0 },
                (agg, cur) => new
                {
                    Depth = agg.Depth + cur.Depth,
                    Horizontal = agg.Horizontal + cur.Horizontal
                });

        return aggregate.Depth * aggregate.Horizontal;
    }
    public static long PuzzleTwo(IEnumerable<string> input)
    {
        var aggregate = input
            .Select(x => new Day02ManualCommand(x))
            .Aggregate(
                new { Aim = 0L, Depth = 0L, Horizontal = 0L },
                (agg, cur) => new
                {
                    Aim = agg.Aim + cur.Aim,
                    Depth = agg.Depth + cur.Forward * agg.Aim,
                    Horizontal = agg.Horizontal + cur.Forward
                });

        return aggregate.Depth * aggregate.Horizontal;
    }
}