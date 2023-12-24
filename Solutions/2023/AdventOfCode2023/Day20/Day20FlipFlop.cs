namespace AdventOfCode2023.Day20;

public class Day20FlipFlop : Day20Module
{
    public Day20FlipFlop(string input) : base(input)
    {
        Name = Name[1..];
    }

    private bool on = false;

    public override IEnumerable<(string Destination, bool Low)> Receive(string source, bool low)
    {
        if (low)
        {
            on = !on;
            return Destinations.Select(x => (x, !on));
        }

        return [];
    }
}
