namespace AdventOfCode2023.Day24;

using Coord = (long X, long Y, long Z);
using Axis = (long Position, long Velocity);

public class Day24Hailstone
{
    // 19, 13, 30 @ -2,  1, -2
    public Day24Hailstone(string input)
    {
        var splits = input.Split(" @ ");
        var coords = splits
            .Select(s =>
            {
                var numbers = s
                    .Split(", ")
                    .Select(long.Parse)
                    .ToArray();
                return (numbers[0], numbers[1], numbers[2]);
            })
            .ToArray();

        Position = coords[0];
        Velocity = coords[1];
        X = (Position.X, Velocity.X);
        Y = (Position.Y, Velocity.Y);
        Z = (Position.Z, Velocity.Z);
    }

    public Coord Position { get; }

    public Coord Velocity { get; }

    public Axis X { get; }

    public Axis Y { get; }

    public Axis Z { get; }
}