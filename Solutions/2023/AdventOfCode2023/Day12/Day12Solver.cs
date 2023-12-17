namespace AdventOfCode2023.Day12;

public static class Day12Solver
{
    public static long PuzzleOne(string input) => input
            .Split(Environment.NewLine)
            .Select(x => new Day12Row(x))
            .Select(GetArrangements)
            .Sum();

    public static long PuzzleTwo(string input) => input
            .Split(Environment.NewLine)
            .Select(x => new Day12Row(x).Unfold())
            .Select(GetArrangements)
            .Sum();

    public static long GetArrangements(Day12Row row)
    {
        var cache = new Dictionary<(string Condition, int LengthIndex, int Damaged), long>();
        var recursed = Recurse(row.Condition, 0, 0);
        return recursed;

        long Recurse(string condition, int lengthIndex, int damaged)
        {
            var cacheKey = (condition, lengthIndex, damaged);
            if (cache.TryGetValue(cacheKey, out var cached))
            {
                return cached;
            }

            if (condition == string.Empty)
            {
                if ((lengthIndex == row.Lengths.Length && damaged == 0)
                    || (lengthIndex == row.Lengths.Length - 1 && row.Lengths[lengthIndex] == damaged))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            var first = condition[0];

            if (first == '.')
            {
                if (damaged > 0)
                {
                    if (lengthIndex >= row.Lengths.Length)
                    {
                        return Cache(0);
                    }

                    var length = row.Lengths[lengthIndex];
                    if (damaged != length)
                    {
                        return Cache(0);
                    }

                    lengthIndex++;
                    damaged = 0;
                }

                return Cache(Recurse(condition[1..], lengthIndex, damaged));
            }
            else if (first == '#')
            {
                damaged++;
                if (lengthIndex >= row.Lengths.Length)
                {
                    return Cache(0);
                }

                if (damaged > row.Lengths[lengthIndex])
                {
                    return Cache(0);
                }

                return Cache(Recurse(condition[1..], lengthIndex, damaged));
            }
            else
            {
                return Cache(Recurse($".{condition[1..]}", lengthIndex, damaged)
                    + Recurse($"#{condition[1..]}", lengthIndex, damaged));
            }

            long Cache(long value)
            {
                cache.Add(cacheKey, value);
                return value;
            }
        }
    }
}