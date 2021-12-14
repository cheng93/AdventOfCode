namespace AdventOfCode2021.Day14;

public static class Day14Solver
{
    public static long PuzzleOne(string input) => Solve(input).Skip(9).First();

    public static long PuzzleTwo(string input) => Solve(input).Skip(39).First();

    private static IEnumerable<long> Solve(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}", StringSplitOptions.RemoveEmptyEntries);

        var template = splits[0];

        var pairs = splits[1]
            .Split(Environment.NewLine)
            .Select(x => x.Split(" -> "))
            .ToDictionary(x => x[0], x => x[1][0]);

        var buckets = pairs.ToDictionary(x => x.Key, x => 0L);

        var counts = pairs.Keys
            .SelectMany(x => new char[] { x[0], x[1] })
            .Distinct()
            .ToDictionary(x => x, x => 0L);

        var polymer = template;
        for (var i = 0; i < polymer.Length - 1; i++)
        {
            var key = $"{polymer[i]}{polymer[i + 1]}";
            buckets[key]++;
            counts[polymer[i]]++;
        }
        counts[polymer.Last()]++;

        for (var i = 0; i < 40; i++)
        {
            var newBuckets = pairs.ToDictionary(x => x.Key, x => 0L);
            foreach (var bucket in buckets)
            {
                var add = pairs[bucket.Key];
                newBuckets[$"{bucket.Key[0]}{add}"] += bucket.Value;
                newBuckets[$"{add}{bucket.Key[1]}"] += bucket.Value;
                counts[add] += bucket.Value;
            }
            buckets = newBuckets;

            yield return counts.Values.Max() - counts.Values.Min();
        }
    }
}