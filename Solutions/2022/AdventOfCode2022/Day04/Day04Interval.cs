namespace AdventOfCode2022.Day04;

public record Day04Interval(int Min, int Max)
{
    public bool Contains(Day04Interval other)
        => Min <= other.Min && Max >= other.Max;

    public bool Intersects(Day04Interval other)
        => Min <= other.Max && Max >= other.Min;
}