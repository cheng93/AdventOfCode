namespace AdventOfCode2021.Day17;

public record Day17Target
{
    // 20..30
    public Day17Target(string input)
    {
        var splits = input.Split("..").Select(int.Parse).ToArray();
        Min = splits[0];
        Max = splits[1];
    }

    public int Min { get; }
    public int Max { get; }
}