namespace AdventOfCode2023.Day18;

public class Day18Step : Day18Instruction
{
    // R 6 (#70c710)
    public Day18Step(string input)
    {
        var splits = input.Split(' ');

        Direction = splits[0] switch
        {
            "R" => 0,
            "D" => 1,
            "L" => 2,
            "U" => 3,
            _ => throw new Exception()
        };
        Number = int.Parse(splits[1]);
        Colour = splits[2][1..^1];
    }

    public string Colour { get; }

    public Day18Instruction ExtractColor()
    {
        var direction = int.Parse(Colour[^1].ToString());
        var number = Convert.ToInt32(Colour[1..^1], 16);

        return new()
        {
            Direction = direction,
            Number = number
        };
    }
}

public class Day18Instruction
{
    public int Direction { get; init; }

    public int Number { get; init; }
}