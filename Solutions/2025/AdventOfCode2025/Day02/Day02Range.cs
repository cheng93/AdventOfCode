namespace AdventOfCode2025.Day02;

public class Day02Range
{
    // 11-22
    public Day02Range(string input)
    {
        var splits = input.Split('-').Select(long.Parse).ToArray();
        Min = splits[0];
        Max = splits[1];
    }
    
    public long Min { get; }
    
    public long Max { get; }
}