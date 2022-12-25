namespace AdventOfCode2016.Day20;

public class Day20Solver
{
    public static long PuzzleOne(IEnumerable<string> input) => Solve(input).First();

    public static long PuzzleTwo(IEnumerable<string> input, long max = 4294967295) => Solve(input, max).Count();

    private static IEnumerable<long> Solve(IEnumerable<string> input, long max = 4294967295)
    {
        var ranges = input.Select(x =>
        {
            var ints = x.Split("-").Select(long.Parse).ToArray();
            return (Min: ints[0], Max: ints[1]);
        });

        var current = 0L;
        foreach (var range in ranges.OrderBy(x => x.Min))
        {
            while (current < range.Min)
            {
                yield return current;
                current++;
            }
            if (range.Min <= current && range.Max >= current)
            {
                current = range.Max + 1;
            }
        }

        for (var i = current; i <= max; i++)
        {
            yield return i;
        }
    }
}