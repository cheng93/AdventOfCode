namespace AdventOfCode2025.Day01;

public static class Day01Solver
{
    public static int PuzzleOne(string input)
    {
        var rotations = input
            .Split(Environment.NewLine)
            .Select(x => new Day01Rotation(x));

        var dial = new Day01Dial(50);
        var count = 0;
        foreach (var rotation in rotations)
        {
            dial.Rotate(rotation);
            if (dial.Value == 0)
            {
                count++;
            }
        }

        return count;
    }

    public static int PuzzleTwo(string input)
    {
        var rotations = input
            .Split(Environment.NewLine)
            .Select(x => new Day01Rotation(x));

        var dial = new Day01Dial(50);

        return rotations.Sum(rotation => dial.Rotate(rotation));
    }
}