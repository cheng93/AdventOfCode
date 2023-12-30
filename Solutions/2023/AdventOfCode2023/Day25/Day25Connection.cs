namespace AdventOfCode2023.Day25;

using Wire = (string Left, string Right);

public class Day25Connection
{
    // jqt: rhn xhk nvd
    public Day25Connection(string input)
    {
        var splits = input.Split(new[] { ": ", " " }, StringSplitOptions.RemoveEmptyEntries);
        var wires = new List<Wire>();
        foreach (var component in splits.Skip(1))
        {
            wires.Add((splits[0], component));
        }
        Wires = wires;
    }

    public IEnumerable<Wire> Wires { get; }
}