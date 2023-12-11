namespace AdventOfCode2023.Day06;

public static class Day06Solver
{
    public static int PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var times = lines[0]["Time:".Length..]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var distances = lines[1]["Distance:".Length..]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        return Enumerable
            .Range(0, times.Length)
            .Aggregate(1, (agg, cur) => agg *= Solve(times[cur], distances[cur]));
    }

    public static long PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var time = int.Parse(lines[0]["Time:".Length..].Replace(" ", string.Empty));

        var distance = long.Parse(lines[1]["Distance:".Length..].Replace(" ", string.Empty));

        return Solve(time, distance);
    }

    // x^2 - tx + d = 0
    private static int Solve(long time, long distance)
    {
        var discriminant = time * time - 4 * distance;

        var rootMin = (time - Math.Sqrt(discriminant)) / 2;
        var rootMax = (time + Math.Sqrt(discriminant)) / 2;
        var output = (int)Math.Floor(rootMax) - (int)Math.Ceiling(rootMin) + 1;
        if (IsInteger(rootMin))
        {
            output -= 1;
        }
        if (IsInteger(rootMax))
        {
            output -= 1;
        }

        return output;

        bool IsInteger(double d) => Math.Abs(d - (int)d) < double.Epsilon;
    }
}