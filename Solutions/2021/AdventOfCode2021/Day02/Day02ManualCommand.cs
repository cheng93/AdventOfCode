namespace AdventOfCode2021.Day02;

public record Day02ManualCommand
{
    // example: forward 5
    public Day02ManualCommand(string input)
    {
        var splits = input.Split(" ");
        var value = int.Parse(splits[1]);

        switch (splits[0])
        {
            case "forward":
                Forward += value;
                break;
            case "down":
                Aim += value;
                break;
            case "up":
                Aim -= value;
                break;
        }

    }

    public int Aim { get; }
    public int Forward { get; }
}