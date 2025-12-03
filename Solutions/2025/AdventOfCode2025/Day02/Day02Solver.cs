namespace AdventOfCode2025.Day02;

public static class Day02Solver
{
    public static long PuzzleOne(string input) => Solve(input, 1);

    public static long PuzzleTwo(string input) => Solve(input);

    private static long Solve(string input, int? maxRepeats = null)
    {
        var ranges = input
            .Split(',')
            .Select(x => new Day02Range(x));

        return ranges
            .SelectMany(GetInvalidIds)
            .Sum();

        IEnumerable<long> GetInvalidIds(Day02Range range)
        {
            var minLog = Log10(range.Min);
            var maxLog = Log10(range.Max);

            var min = DivPow10(range.Min, minLog / 2 + 1);
            var max = maxLog % 2 != 0
                ? DivPow10(range.Max, (maxLog + 1) / 2)
                : (long)Math.Pow(10, maxLog / 2) - 1;

            var seen = new HashSet<long>();
            // for part 1, set i to min, to further optimize
            for (var i = 1L; i <= max; i++)
            {
                var id = i;
                var repeats = 0;
                while (id < range.Max && (!maxRepeats.HasValue || repeats < maxRepeats))
                {
                    id = id * (long)Math.Pow(10, Log10(i) + 1) + i;
                    repeats++;
                    if (seen.Contains(id))
                    {
                        continue;
                    }

                    if (id >= range.Min && id <= range.Max)
                    {
                        yield return id;
                        seen.Add(id);
                    }
                }
            }

            int Log10(long x) => (int)Math.Floor(Math.Log10(x));

            long DivPow10(long x, int power) => x / (long)Math.Pow(10, power);
        }
    }
}