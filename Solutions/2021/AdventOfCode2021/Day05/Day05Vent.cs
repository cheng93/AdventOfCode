namespace AdventOfCode2021.Day05;

public class Day05Vent
{
    // example: 0,9 -> 5,9
    public Day05Vent(string input)
    {
        var splits = input.Split(" -> ");

        Start = Parse(splits[0]);
        End = Parse(splits[1]);
    }

    public (int X, int Y) Start { get; }
    public (int X, int Y) End { get; }

    private static (int X, int Y) Parse(string input)
    {
        var splits = input.Split(",").Select(int.Parse).ToArray();

        return (splits[0], splits[1]);
    }
}