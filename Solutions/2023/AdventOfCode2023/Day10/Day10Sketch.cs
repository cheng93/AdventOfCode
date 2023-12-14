namespace AdventOfCode2023.Day10;

using Coord = (int X, int Y);

public class Day10Sketch
{
    public Day10Sketch(string input)
    {
        var lines = input.Split(Environment.NewLine);
        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                var character = line[x];
                Map[(x, y)] = character;

                if (character == 'S')
                {
                    Start = (x, y);
                }
            }
        }
    }

    public Dictionary<Coord, char> Map { get; } = new();

    public Coord Start { get; }
}