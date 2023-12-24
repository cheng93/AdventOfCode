namespace AdventOfCode2023.Day19;

using Range = (int Min, int Max);

public class Day19Ranges
{
    public Range X { get; private set; } = (1, 4000);

    public Range M { get; private set; } = (1, 4000);

    public Range A { get; private set; } = (1, 4000);

    public Range S { get; private set; } = (1, 4000);

    public long Combinations => new[] { X, M, A, S }
        .Select(r => r.Max - r.Min + 1)
        .Aggregate(1L, (agg, cur) => agg *= cur);

    public Day19Ranges? GetBefore(char category, int number)
    {
        var clone = Clone();
        var range = GetRange(category);
        if (number <= range.Min)
        {
            return null;
        }
        clone.SetRange(category, (range.Min, Math.Min(range.Max, number - 1)));
        return clone;
    }

    public Day19Ranges? GetAfter(char category, int number)
    {
        var clone = Clone();
        var range = GetRange(category);
        if (number >= range.Max)
        {
            return null;
        }
        clone.SetRange(category, (Math.Max(range.Min, number + 1), range.Max));
        return clone;
    }

    private Day19Ranges Clone()
        => new()
        {
            X = X,
            M = M,
            A = A,
            S = S
        };

    private Range GetRange(char category)
        => category switch
        {
            'x' => X,
            'm' => M,
            'a' => A,
            's' => S,
            _ => throw new Exception()
        };

    private void SetRange(char category, Range range)
    {
        switch (category)
        {
            case 'x':
                X = range;
                break;
            case 'm':
                M = range;
                break;
            case 'a':
                A = range;
                break;
            case 's':
                S = range;
                break;
        }
    }
}