namespace AdventOfCode2023.Day20;

public class Day20Broadcast(string input) : Day20Module(input)
{
    public override IEnumerable<(string Destination, bool Low)> Receive(string source, bool low)
        => Destinations.Select(x => (x, low));
}