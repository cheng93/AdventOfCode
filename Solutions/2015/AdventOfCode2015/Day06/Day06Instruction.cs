namespace AdventOfCode2015.Day06;

using Coord = (int X, int Y);

public class Day06Instruction
{
    // turn on 0,0 through 999,999
    // toggle 0,0 through 999,0
    // turn off 499,499 through 500,500
    public Day06Instruction(string input)
    {
        if (input.StartsWith("turn"))
        {
            input = input[("turn ".Length)..];
        }
        var splits = input.Split(' ');

        Phrase = splits[0];

        var coords = new[] { splits[1], splits[3] }
            .Select(x =>
            {
                var numbers = x
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();

                return (numbers[0], numbers[1]);
            })
            .ToArray();

        Start = coords[0];
        End = coords[1];
    }

    public Coord Start { get; }

    public Coord End { get; }

    public string Phrase { get; }
}