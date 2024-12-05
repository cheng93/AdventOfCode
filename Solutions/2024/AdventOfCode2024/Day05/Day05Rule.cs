namespace AdventOfCode2024.Day05;

public class Day05Rule
{
    // 47|53
    public Day05Rule(string input)
    {
        var splits = input
            .Split('|')
            .Select(int.Parse)
            .ToArray();

        Before = splits[0];
        After = splits[1];
    }

    public int After { get; }

    public int Before { get; }
}