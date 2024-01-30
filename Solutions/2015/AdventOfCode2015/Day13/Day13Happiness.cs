namespace AdventOfCode2015.Day13;

public class Day13Happiness
{
    // Alice would gain 54 happiness units by sitting next to Bob.
    // Alice would lose 79 happiness units by sitting next to Carol.
    public Day13Happiness(string input)
    {
        var splits = input.Split(' ');

        Host = splits[0];
        Neighbour = splits[^1][..^1];
        Value = int.Parse(splits[3]);
        if (splits[2] == "lose")
        {
            Value *= -1;
        }
    }

    public string Host { get; }

    public string Neighbour { get; }

    public int Value { get; }
}