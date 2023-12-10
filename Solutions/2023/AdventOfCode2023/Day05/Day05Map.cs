namespace AdventOfCode2023.Day05;

using Bound = (long Min, long Max);

public class Day05Map
{
    /*
    input

    seed-to-soil map:
    50 98 2
    52 50 48
    */
    public Day05Map(string input)
    {
        Ranges = input
            .Split(Environment.NewLine)
            .Skip(1)
            .Select(x => new Day05Range(x))
            .ToArray();
    }

    public IEnumerable<Day05Range> Ranges { get; set; }

    public long GetValue(long input)
    {
        foreach (var range in Ranges)
        {
            if (input >= range.Source && input <= range.Source + range.Length)
            {
                return range.Destination + input - range.Source;
            }
        }

        return input;
    }

    public IEnumerable<Bound> GetBounds(Bound bound)
    {
        var min = long.MaxValue;
        var max = long.MinValue;
        var gaps = new List<Bound>();
        var expectedNext = Ranges.Select(r => r.Source).Min();

        foreach (var range in Ranges.OrderBy(r => r.Source))
        {
            if (range.Source < min)
            {
                min = range.Source;
            }
            var sourceMax = range.Source + range.Length - 1;
            if (sourceMax > max)
            {
                max = sourceMax;
            }

            if (range.Source != expectedNext)
            {
                gaps.Add((expectedNext, range.Source - 1));
            }

            if (IsInBetween((range.Source, sourceMax)))
            {
                var subbound = GetSubbound((range.Source, sourceMax));
                var offset = subbound.Min - range.Source;
                var length = subbound.Max - subbound.Min;
                var destinationMin = range.Destination + offset;
                yield return (destinationMin, destinationMin + length);
            }

            expectedNext = range.Source + range.Length;
        }

        gaps.Add((max + 1, long.MaxValue));

        if (min != 0)
        {
            gaps.Add((0, min - 1));
        }

        foreach (var gap in gaps.Where(IsInBetween))
        {
            yield return GetSubbound(gap);
        }

        bool IsInBetween(Bound range)
            => bound.Min <= range.Max && bound.Max >= range.Min;

        Bound GetSubbound(Bound source)
        {
            var min = Math.Max(source.Min, bound.Min);
            var max = Math.Min(source.Max, bound.Max);

            return (min, max);
        }
    }
}