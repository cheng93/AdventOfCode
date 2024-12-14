using System.Numerics;

namespace AdventOfCode2024.Day14;

public class Day14Robot
{
    // p=0,4 v=3,-3
    public Day14Robot(string input)
    {
        var splits = input
            .Replace("p", string.Empty)
            .Replace("v", string.Empty)
            .Replace("=", string.Empty)
            .Replace(" ", ",")
            .Split(',')
            .Select(int.Parse)
            .ToArray();

        Position = splits[0] + splits[1] * Complex.ImaginaryOne;
        Velocity = splits[2] + splits[3] * Complex.ImaginaryOne;
    }

    public Complex Position { get; }

    public Complex Velocity { get; }
}