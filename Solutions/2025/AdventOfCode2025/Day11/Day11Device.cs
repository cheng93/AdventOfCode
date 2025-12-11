namespace AdventOfCode2025.Day11;

public class Day11Device
{
    // aaa: you hhh
    public Day11Device(string input)
    {
        var splits = input.Split(": ");
        Name = splits[0];
        Outputs = splits[1].Split(' ');
    }
    
    public string Name { get; }
    
    public string[] Outputs { get; }
}