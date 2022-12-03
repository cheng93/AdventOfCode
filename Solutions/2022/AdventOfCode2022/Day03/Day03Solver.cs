namespace AdventOfCode2022.Day03;

public static class Day03Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return input
            .Select(x => new Day03Rucksack(x))
            .Select(x => x.Compartments
                .First()
                .Intersect(x.Compartments.Last())
                .Single())
            .Sum(x => letters.IndexOf(x) + 1);
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return input
            .Select(x=> new Day03Rucksack(x))
            .Chunk(3)
            .Select(x => x
                .Select(x => x.Items.AsEnumerable())
                .Aggregate(
                    (agg, cur) => agg.Intersect(cur))
                .Single())
            .Sum(x => letters.IndexOf(x) + 1);
    }
}