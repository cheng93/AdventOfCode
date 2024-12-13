using System.Numerics;

namespace AdventOfCode2024.Day13;

public class Day13Machine
{
    /*
    Button A: X+94, Y+34
    Button B: X+22, Y+67
    Prize: X=8400, Y=5400
    */
    public Day13Machine(string input)
    {
        var lines = input
            .Replace(",", string.Empty)
            .Split(Environment.NewLine)
            .ToArray();
        var buttons = lines
            .Take(2)
            .Select(x => x.Split(' ').Skip(2))
            .Select(GetPosition)
            .ToArray();
        A = buttons[0];
        B = buttons[1];
        Prize = GetPosition(lines[2].Split(' ').Skip(1));

        Position GetPosition(IEnumerable<string> enumerable)
        {
            var numbers = enumerable
               .Select(y => int.Parse(y[2..]))
               .ToArray();

            return new(numbers[0], numbers[1]);
        }
    }

    public Position A { get; }

    public Position B { get; }

    public Position Prize { get; }

    public record Position(int X, int Y);
}