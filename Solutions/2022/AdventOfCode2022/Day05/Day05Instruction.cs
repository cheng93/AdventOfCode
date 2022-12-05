namespace AdventOfCode2022.Day05;

public record Day05Instruction
{
    // move 1 from 2 to 1
    public Day05Instruction(string input)
    {
        var numbers = input
            .Split(" ")
            .Where(x => int.TryParse(x, out var _))
            .Select(int.Parse)
            .ToArray();

        Count = numbers[0];
        From = numbers[1] - 1;
        To = numbers[2] - 1;
    }

    public int Count { get; }

    public int From { get; }

    public int To { get; }
}