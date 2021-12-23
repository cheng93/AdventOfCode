namespace AdventOfCode2021.Day22;

public record Day22Cuboid
{
    public Day22Cuboid(Day22Range x, Day22Range y, Day22Range z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Day22Range X { get; }
    public Day22Range Y { get; }
    public Day22Range Z { get; }

    public long Volume => 1L * X.Length * Y.Length * Z.Length;

    public IEnumerable<Day22Cuboid> Intersect(Day22Cuboid cuboid)
    {
        if (!X.HasIntersection(cuboid.X)
            || !Y.HasIntersection(cuboid.Y)
            || !Z.HasIntersection(cuboid.Z))
        {
            yield return cuboid;
        }
        else if (TotallyContain(cuboid))
        {
            yield break;
        }
        else
        {
            var xIntervals = X.GetIntervals(cuboid.X).ToArray();
            var yIntervals = Y.GetIntervals(cuboid.Y).ToArray();
            var zIntervals = Z.GetIntervals(cuboid.Z).ToArray();

            var interval = xIntervals[0];
            if (interval.Length > 1 && interval.Min == cuboid.X.Min)
            {
                yield return new Day22Cuboid(new(interval.Min, interval.Max - 1), cuboid.Y, cuboid.Z);
            }
            interval = xIntervals[2];
            if (interval.Length > 1 && interval.Max == cuboid.X.Max)
            {
                yield return new Day22Cuboid(new(interval.Min + 1, interval.Max), cuboid.Y, cuboid.Z);
            }

            interval = yIntervals[0];
            if (interval.Length > 1 && interval.Min == cuboid.Y.Min)
            {
                yield return new Day22Cuboid(xIntervals[1], new(interval.Min, interval.Max - 1), cuboid.Z);
            }
            interval = yIntervals[2];
            if (interval.Length > 1 && interval.Max == cuboid.Y.Max)
            {
                yield return new Day22Cuboid(xIntervals[1], new(interval.Min + 1, interval.Max), cuboid.Z);
            }

            interval = zIntervals[0];
            if (interval.Length > 1 && interval.Min == cuboid.Z.Min)
            {
                yield return new Day22Cuboid(xIntervals[1], yIntervals[1], new(interval.Min, interval.Max - 1));
            }
            interval = zIntervals[2];
            if (interval.Length > 1 && interval.Max == cuboid.Z.Max)
            {
                yield return new Day22Cuboid(xIntervals[1], yIntervals[1], new(interval.Min + 1, interval.Max));
            }
        }
    }

    public bool TotallyContain(Day22Cuboid cuboid)
        => X.Min <= cuboid.X.Min
            && X.Max >= cuboid.X.Max
            && Y.Min <= cuboid.Y.Min
            && Y.Max >= cuboid.Y.Max
            && Z.Min <= cuboid.Z.Min
            && Z.Max >= cuboid.Z.Max;
}

public record Day22Range(int Min, int Max)
{
    public int Length => Math.Abs(Max - Min) + 1;

    public IEnumerable<Day22Range> GetIntervals(Day22Range range)
    {
        var numbers = new[] { Min, Max, range.Min, range.Max }
            .OrderBy(x => x)
            .ToArray();

        for (var i = 0; i < numbers.Length - 1; i++)
        {
            yield return new(numbers[i], numbers[i + 1]);
        }
    }

    public bool HasIntersection(Day22Range range)
        => range.Min <= Max && range.Max >= Min;
}