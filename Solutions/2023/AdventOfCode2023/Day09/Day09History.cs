using MoreLinq;

namespace AdventOfCode2023.Day09;

public class Day09History
{
    // input: 0 3 6 9 12 15
    public Day09History(string input)
    {
        Values = input
            .Split(" ")
            .Select(long.Parse)
            .ToArray();
    }

    private Day09History(IEnumerable<long> values)
    {
        Values = values;
    }

    public IEnumerable<long> Values { get; }

    public long GetNext()
    {
        if (Values.All(x => x == 0))
        {
            return 0;
        }

        var history = new Day09History(Values.Lag(1, (cur, prev) => cur - prev).Skip(1));
        return Values.Last() + history.GetNext();
    }

    public long GetPrevious()
    {
        if (Values.All(x => x == 0))
        {
            return 0;
        }

        var history = new Day09History(Values.Lag(1, (cur, prev) => cur - prev).Skip(1));
        return Values.First() - history.GetPrevious();
    }
}