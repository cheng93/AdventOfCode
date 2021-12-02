namespace AdventOfCode2021.Day02;

public record Day02Command
{
    // example: forward 5
    public Day02Command(string input)
    {
        var splits = input.Split(" ");
        var value = int.Parse(splits[1]);

        switch (splits[0])
        {
            case "forward":
                Horizontal += value;
                break;
            case "down":
                Depth += value;
                break;
            case "up":
                Depth -= value;
                break;
        }

    }

    public int Depth { get; }
    public int Horizontal { get; }
}