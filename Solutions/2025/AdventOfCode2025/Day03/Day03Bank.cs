namespace AdventOfCode2025.Day03;

// 987654321111111
public class Day03Bank(string input)
{
    public int[] Batteries { get; } = input.Select(x => int.Parse(x.ToString())).ToArray();
}