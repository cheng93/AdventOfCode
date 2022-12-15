using System.Numerics;

namespace AdventOfCode2022.Day15;

public class Day15Sensor
{
    // Sensor at x=2, y=18: closest beacon is at x=-2, y=15
    public Day15Sensor(string input)
    {
        var numbers = input
            .Split(new[] { "x=", ", y=", ":", }, StringSplitOptions.RemoveEmptyEntries)
            .Where(x => int.TryParse(x, out var _))
            .Select(int.Parse).ToArray();

        Position = (numbers[0], numbers[1]);
        Beacon = (numbers[2], numbers[3]);
        manhattanDistance = ManhattanDistance(Position, Beacon);
    }

    public (int X, int Y) Position { get; }

    public (int X, int Y) Beacon { get; }

    private readonly int manhattanDistance;

    public IEnumerable<(int X, int Y)> Scan()
    {
        var distance = ManhattanDistance(Position, Beacon);
        var factors = new int[] { 1, -1 };

        for (var i = 0; i <= distance; i++)
        {
            for (var j = 0; j <= distance - i; j++)
            {
                for (var k = 0; k <= Math.Sign(i); k++)
                {
                    for (var l = 0; l <= Math.Sign(j); l++)
                    {
                        yield return (Position.X + i * factors[k], Position.Y + j * factors[l]);
                    }
                }
            }
        }
    }

    public IEnumerable<int> ScanY(int y)
    {
        var distance = ManhattanDistance(Position, (Position.X, y));
        if (distance > manhattanDistance)
        {
            yield break;
        }

        yield return Position.X;
        for (var i = 1; i <= manhattanDistance - distance; i++)
        {
            yield return 1 * i + Position.X;
            yield return -1 * i + Position.X;
        }
    }

    public IEnumerable<(int X, int Y)> GetPerimeter()
    {
        var distance = manhattanDistance + 1;
        var factors = new[] { 1, -1 };
        for (var x = 0; x <= distance; x++)
        {
            var y = distance - x;

            for (var i = 0; i <= Math.Sign(x); i++)
            {
                for (var j = 0; j <= Math.Sign(y); j++)
                {
                    yield return (Position.X + x * factors[i], Position.Y + y * factors[j]);
                }
            }
        }
    }

    public bool Contains((int X, int Y) point)
        => ManhattanDistance(Position, point) <= manhattanDistance;

    private static int ManhattanDistance((int X, int Y) a, (int X, int Y) b)
    {
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}