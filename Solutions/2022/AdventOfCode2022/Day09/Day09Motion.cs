namespace AdventOfCode2022.Day09;

public record Day09Motion
{
    // R 4
    public Day09Motion(string input)
    {
        var splits = input.Split(" ");
        Direction = splits[0];
        Steps = int.Parse(splits[1]);

    }

    public string Direction { get; }

    public int Steps { get; }
}