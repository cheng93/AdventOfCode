namespace AdventOfCode2023.Day15;

public static class Day15Solver
{
    public static int PuzzleOne(string input)
        => input
            .Split(',')
            .Select(Hash)
            .Sum();

    public static int PuzzleTwo(string input)
    {
        var steps = input
            .Split(',')
            .Select(x => new Day15Step(x))
            .ToArray();

        var boxes = Enumerable
            .Range(0, 256)
            .Select(x => new Day15Box())
            .ToArray();

        foreach (var step in steps)
        {
            var boxId = Hash(step.Label);
            var box = boxes[boxId];
            if (step.Operation == '-')
            {
                box.Dash(step.Label);
            }
            else if (step.Operation == '=')
            {
                box.Equals((step.Label, step.Number));
            }
        }

        return boxes
            .SelectMany((box, i) => box
                .FocusingPower()
                .Select(fp => (i + 1) * fp))
            .Sum();
    }

    private static int Hash(string input)
    {
        var value = 0;

        foreach (var character in input)
        {
            value += character;
            value *= 17;
            value %= 256;
        }

        return value;
    }
}