using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day16;

public class Day16Valve
{
    // Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
    public Day16Valve(string input)
    {
        var match = Regex.Match(input, @"Valve (.+?) has flow rate=(\d+); tunnels? leads? to valves? (.+)");

        Id = match.Groups[1].Value;
        FlowRate = int.Parse(match.Groups[2].Value);
        Next = match.Groups[3].Value.Split(", ");
    }

    public string Id { get; }

    public int FlowRate { get; }

    public IEnumerable<string> Next { get; }
}