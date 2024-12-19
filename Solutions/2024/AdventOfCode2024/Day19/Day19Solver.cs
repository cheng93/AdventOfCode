namespace AdventOfCode2024.Day19;

public static class Day19Solver
{
    public static int PuzzleOne(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var towels = splits[0].Split(", ");

        var cache = new Dictionary<string, bool>();

        return splits[1]
            .Split(Environment.NewLine)
            .Count(IsPossible);

        bool IsPossible(string pattern)
        {
            if (cache.TryGetValue(pattern, out var cached))
            {
                return cached;
            }
            if (pattern == string.Empty)
            {
                return true;
            }

            foreach (var towel in towels)
            {
                if (pattern.StartsWith(towel) && IsPossible(pattern.Substring(towel.Length)))
                {
                    cache.Add(pattern, true);
                    return true;
                }
            }

            cache.Add(pattern, false);
            return false;
        }
    }

    public static long PuzzleTwo(string input)
    {
        var splits = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var towels = splits[0].Split(", ");

        var cache = new Dictionary<string, long>();

        return splits[1]
            .Split(Environment.NewLine)
            .Sum(Arrangements);

        long Arrangements(string pattern)
        {
            if (cache.TryGetValue(pattern, out var cached))
            {
                return cached;
            }
            if (pattern == string.Empty)
            {
                return 1;
            }

            var arrangements = 0L;
            foreach (var towel in towels)
            {
                if (pattern.StartsWith(towel))
                {
                    arrangements += Arrangements(pattern.Substring(towel.Length));
                }
            }

            cache.Add(pattern, arrangements);
            return arrangements;
        }
    }
}