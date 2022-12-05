namespace AdventOfCode2022.Day05;

public static class Day05Solver
{
    public static string PuzzleOne(string input)
    {
        var parts = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var crane = new Day05Crane(parts[0]);
        var instructions = parts[1]
            .Split(Environment.NewLine)
            .Select(x => new Day05Instruction(x));

        foreach (var instruction in instructions)
        {
            crane.Move9000(instruction);
        }

        return crane.Read();
    }

    public static string PuzzleTwo(string input)
    {
        var parts = input.Split($"{Environment.NewLine}{Environment.NewLine}");

        var crane = new Day05Crane(parts[0]);
        var instructions = parts[1]
            .Split(Environment.NewLine)
            .Select(x => new Day05Instruction(x));

        foreach (var instruction in instructions)
        {
            crane.Move9001(instruction);
        }

        return crane.Read();
    }
}