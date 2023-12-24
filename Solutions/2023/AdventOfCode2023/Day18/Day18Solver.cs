namespace AdventOfCode2023.Day18;

using Coord = (int X, int Y);

public static class Day18Solver
{
    public static long PuzzleOne(string input) => Solve(input, x => x);

    public static long PuzzleTwo(string input) => Solve(input, x => x.ExtractColor());

    private static long Solve(string input, Func<Day18Step, Day18Instruction> selector)
    {
        var instructions = input
            .Split(Environment.NewLine)
            .Select(x => new Day18Step(x))
            .Select(selector)
            .ToArray();

        var modifiers = new Coord[]
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1),
        };

        var area = 0L;
        var perimeter = 0L;

        Coord current = (0, 0);

        foreach (var instruction in instructions)
        {
            var modifier = modifiers[instruction.Direction];
            Coord newCurrent = (current.X + modifier.X * instruction.Number, current.Y + modifier.Y * instruction.Number);

            var x = current.X - newCurrent.X;
            var y = current.Y + newCurrent.Y;

            area += 1L * x * y;
            perimeter += instruction.Number;

            current = newCurrent;
        }

        return (area + perimeter) / 2 + 1;
    }
}