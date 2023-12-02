namespace AdventOfCode2023.Day02;

public class Day02Set
{
    // 3 blue, 4 red
    public Day02Set(string input)
    {
        var splits = input.Split(", ");
        foreach (var split in splits)
        {
            var parts = split.Split(" ");
            var amount = int.Parse(parts[0]);
            var colour = parts[1];
            switch (colour)
            {
                case "red":
                    Red += amount;
                    break;
                case "green":
                    Green += amount;
                    break;
                case "blue":
                    Blue += amount;
                    break;
            }
        }
    }

    public int Red { get; set; } = 0;

    public int Green { get; set; } = 0;

    public int Blue { get; set; } = 0;
}