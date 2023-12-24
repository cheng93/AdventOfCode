namespace AdventOfCode2023.Day20;

public interface IDay20Module
{
    string Name { get; }

    IEnumerable<string> Destinations { get; }

    IEnumerable<(string Destination, bool Low)> Receive(string source, bool low);
}

public abstract class Day20Module : IDay20Module
{
    // broadcaster -> a, b, c
    public Day20Module(string input)
    {
        var splits = input.Split(" -> ");
        Name = splits[0];
        Destinations = splits[1].Split(", ");
    }

    public IEnumerable<string> Destinations { get; }

    public string Name { get; protected set; }

    public abstract IEnumerable<(string Destination, bool Low)> Receive(string source, bool low);
}