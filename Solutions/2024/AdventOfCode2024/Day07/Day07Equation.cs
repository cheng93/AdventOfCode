namespace AdventOfCode2024.Day07;

public class Day07Equation
{
    // 190: 10 19
    public Day07Equation(string input)
    {
        var splits = input.Split(": ");
        Value = long.Parse(splits[0]);
        Numbers = splits[1]
            .Split(" ")
            .Select(long.Parse)
            .ToArray();
    }

    public long[] Numbers { get; }

    public long Value { get; }
}