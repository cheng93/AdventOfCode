namespace AdventOfCode2015.Day19;

public class Day19Replacement
{
    // H => HO
    public Day19Replacement(string input)
    {
        var splits = input.Split(" => ");
        From = splits[0];
        To = splits[1];
    }

    public string From { get; }

    public string To { get; }
}