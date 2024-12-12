namespace AdventOfCode2024.Day11;

public static class Day11Solver
{
    public static long PuzzleOne(string input) => Solve(input, 25);

    public static long PuzzleTwo(string input) => Solve(input, 75);

    private static long Solve(string input, int blinks)
    {
        var cache = new Dictionary<CacheKey, long>();

        return input.Split(' ')
            .Select(long.Parse)
            .Sum(x => Grow(x, blinks));


        long Grow(long seed, int limit)
        {
            var cacheKey = new CacheKey(seed, limit);
            if (cache.TryGetValue(cacheKey, out var cached))
            {
                return cached;
            }

            if (limit == 0)
            {
                return 1;
            }
            var stones = new LinkedList<long>();
            stones.AddLast(seed);

            var current = stones.First;
            while (current != null)
            {
                var power = (int)Math.Floor(Math.Log10(current.Value));
                if (current.Value == 0)
                {
                    current.Value = 1;
                }
                else if (power % 2 == 1)
                {
                    var halved = (power + 1) / 2;
                    var mod = current.Value % PowerOfTen(halved);
                    stones.AddAfter(current, mod);
                    current.Value -= mod;
                    current.Value /= PowerOfTen(halved);
                    current = current.Next;
                }
                else
                {
                    current.Value *= 2024;
                }
                current = current!.Next;
            }

            cached = stones.Sum(x => Grow(x, limit - 1));
            cache.Add(cacheKey, cached);

            return cached;
        }

        long PowerOfTen(int power)
            => Enumerable.Range(0, power).Aggregate(1L, (agg, cur) => agg * 10);
    }

    private record CacheKey(long Seed, int Limit);
}