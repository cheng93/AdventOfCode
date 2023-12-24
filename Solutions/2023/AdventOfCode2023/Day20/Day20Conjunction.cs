namespace AdventOfCode2023.Day20;

public class Day20Conjunction : Day20Module
{
    public Day20Conjunction(string input) : base(input)
    {
        Name = Name[1..];
    }

    private readonly Dictionary<string, bool> store = new();

    public override IEnumerable<(string Destination, bool Low)> Receive(string source, bool low)
    {
        store[source] = low;
        return Destinations.Select(x => (x, Low));
    }

    public void AddSource(string source) => store[source] = true;

    public bool Low => store.Values.All(x => !x);
}