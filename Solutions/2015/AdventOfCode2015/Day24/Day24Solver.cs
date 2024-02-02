namespace AdventOfCode2015.Day24;

public static class Day24Solver
{
    public static long PuzzleOne(string input) => Solve(input, 3);

    public static long PuzzleTwo(string input) => Solve(input, 4);

    private static long Solve(string input, int numberOfGroups)
    {
        var weights = input
            .Split(Environment.NewLine)
            .Select(int.Parse)
            .ToArray();
        var groupWeight = weights.Sum() / numberOfGroups;

        var cache = new Dictionary<string, List<int[]>>();
        var group = GetGroup(weights, 0)
            .OrderBy(g => g.Length)
            .ThenBy(g => g.Aggregate(1L, (agg, cur) => agg * cur))
            .First(g => IsValid(g, 1));

        return group.Aggregate(1L, (agg, cur) => agg * cur);

        bool IsValid(int[] values, int depth)
        {
            if (depth == numberOfGroups)
            {
                return true;
            }

            var except = weights.Except(values);
            foreach (var g in GetGroup(except, 0))
            {
                return IsValid([.. values, .. g], depth + 1);
            }
            return false;
        }

        IEnumerable<int[]> GetGroup(IEnumerable<int> values, int sum)
        {
            if (sum == groupWeight)
            {
                yield return [];
                yield break;
            }
            var cacheKey = GetCacheKey();
            if (cache.TryGetValue(cacheKey, out var cached))
            {
                foreach (var item in cached)
                {
                    yield return item;
                }
                yield break;
            }
            cache.Add(cacheKey, new());

            var remainder = groupWeight - sum;

            foreach (var value in values)
            {
                if (value > remainder)
                {
                    continue;
                }

                var newSum = sum + value;
                var filtered = values.Where(x => x > value);
                foreach (var group in GetGroup(filtered, newSum))
                {
                    int[] bla = [value, .. group];
                    cache[cacheKey].Add(bla);
                    yield return bla;
                }
            }

            string GetCacheKey() => string.Join<int>(",", [.. values, sum]);
        }
    }
}