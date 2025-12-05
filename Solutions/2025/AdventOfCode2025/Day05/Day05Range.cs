namespace AdventOfCode2025.Day05;

public class Day05Range
{
    // 11-22
    public Day05Range(string input)
    {
        var splits = input.Split('-').Select(long.Parse).ToArray();
        Min = splits[0];
        Max = splits[1];
    }

    public Day05Range(long min, long max)
    {
        Min = min;
        Max = max;
    }
    
    public long Min { get; }
    
    public long Max { get; }
}