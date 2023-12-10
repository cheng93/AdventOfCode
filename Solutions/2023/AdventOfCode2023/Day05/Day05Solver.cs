namespace AdventOfCode2023.Day05;

using Bound = (long Min, long Max);

public static class Day05Solver
{
    public static long PuzzleOne(string input)
    {
        var splits = input
            .Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var seeds = splits[0]["seeds: ".Length..]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse);

        var maps = splits
            .Skip(1)
            .Select(x => new Day05Map(x))
            .ToArray();

        return seeds
            .Select(seed => maps.Aggregate(seed, (agg, cur) => cur.GetValue(agg)))
            .Min();
    }


    public static long PuzzleTwo(string input)
    {
        var splits = input
            .Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        var seeds = new List<Bound>();

        var seedRanges = splits[0]["seeds: ".Length..]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

        for (var i = 0; i < seedRanges.Length; i += 2)
        {
            seeds.Add((seedRanges[i], seedRanges[i] + seedRanges[i + 1] - 1));
        }

        var maps = splits
            .Skip(1)
            .Select(x => new Day05Map(x))
            .ToArray();

        var min = long.MaxValue;
        var queue = new Queue<(Bound Bound, int MapIndex)>();
        foreach (var seed in seeds)
        {
            queue.Enqueue((seed, 0));
        }

        while (queue.Any())
        {
            var item = queue.Dequeue();
            var bounds = maps[item.MapIndex].GetBounds(item.Bound).ToList();
            if (item.MapIndex == maps.Length - 1)
            {
                min = Math.Min(min, bounds.Select(bound => bound.Min).Min());
            }
            else
            {
                foreach (var bound in bounds)
                {
                    queue.Enqueue((bound, item.MapIndex + 1));
                }
            }
        }

        return min;
    }
}