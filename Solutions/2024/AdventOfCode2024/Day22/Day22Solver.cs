namespace AdventOfCode2024.Day22;

public static class Day22Solver
{
    public static long PuzzleOne(string input)
    {
        return input
            .Split(Environment.NewLine)
            .Select(long.Parse)
            .Select(x => Generate(x).Skip(2000).First())
            .Select(x => x)
            .Sum();
    }

    public static int PuzzleTwo(string input)
    {
        var seeds = input
            .Split(Environment.NewLine)
            .Select(long.Parse)
            .ToArray();

        var counts = new Dictionary<string, int>();

        foreach (var seed in seeds)
        {
            var i = 0;
            var prev = 0;
            var changes = new LinkedList<int>();
            var seen = new HashSet<string>();
            foreach (var secretNumber in Generate(seed).Take(2001))
            {
                var current = (int)(secretNumber % 10);
                if (i > 0)
                {
                    var diff = current - prev;
                    changes.AddLast(diff);
                }
                if (i >= 4)
                {
                    var key = string.Join(",", changes);
                    if (!counts.TryGetValue(key, out var value))
                    {
                        counts.Add(key, 0);
                    }
                    if (!seen.Contains(key))
                    {
                        counts[key] += current;
                    }
                    seen.Add(key);
                    changes.RemoveFirst();
                }

                prev = current;
                i++;
            }
        }

        return counts.Values.Max();
    }

    private static IEnumerable<long> Generate(long seed)
    {
        var current = seed;
        while (true)
        {
            yield return current;
            current = (current ^ (current * 64)) % 16777216;
            current = (current ^ (current / 32)) % 16777216;
            current = (current ^ (current * 2048)) % 16777216;
        }
    }
}