namespace AdventOfCode2023.Day08;

public class Day08Node
{
    // input: AAA = (BBB, CCC)
    public Day08Node(string input)
    {
        var splits = input.Split(new[] { " = ", ", " }, StringSplitOptions.RemoveEmptyEntries);

        Id = splits[0];
        Left = splits[1][1..];
        Right = splits[2][..^1];
    }

    public string Id { get; set; }

    public string Left { get; set; }

    public string Right { get; set; }
}