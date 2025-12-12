namespace AdventOfCode2025.Day12;

public class Day12Region
{
    // 4x4: 0 0 0 0 2 0
    public Day12Region(string input)
    {
        var splits = input.Split(": ");
        var units = splits[0]
            .Split('x')
            .Select(int.Parse)
            .ToArray();

        Height = units[0];
        Width = units[1];
        Quantities = splits[1]
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
    }

    public int Height { get; }
    
    public int Width { get; }

    public int[] Quantities { get; }
}