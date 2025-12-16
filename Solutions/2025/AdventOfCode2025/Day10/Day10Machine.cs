using System.Text.RegularExpressions;

namespace AdventOfCode2025.Day10;

public class Day10Machine
{
    // [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
    public Day10Machine(string input)
    {
        var match = Regex.Match(input, @"\[([.#]+)\](?:\s\((.*?)\))+\s\{(.*?)\}");
        Goal = match.Groups[1].Value
            .Select(x => x == '#')
            .ToArray();
        Buttons = match.Groups[2].Captures
            .Select(x => x.Value.Split(',').Select(int.Parse).ToArray())
            .ToArray();
        Joltages = match.Groups[3].Value
            .Split(',')
            .Select(int.Parse)
            .ToArray();
    }
    
    public bool[] Goal { get; }
    
    public int[][] Buttons { get; }
    
    public int[] Joltages { get; }
}