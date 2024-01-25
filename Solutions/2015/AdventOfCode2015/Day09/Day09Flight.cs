namespace AdventOfCode2015.Day09;

public class Day09Flight
{
    // London to Dublin = 464
    public Day09Flight(string input)
    {
        var splits = input.Split([" to ", " = "], StringSplitOptions.RemoveEmptyEntries);

        From = splits[0];
        To = splits[1];
        Distance = int.Parse(splits[2]);
    }

    public string From { get; }

    public string To { get; }

    public int Distance { get; }
}