namespace AdventOfCode2021.Day20;

public record Day20Image
{
    public Day20Image(HashSet<(int X, int Y)> lightPixels, char background)
    {
        LightPixels = lightPixels;
        Background = background;
    }

    public HashSet<(int X, int Y)> LightPixels { get; }
    public char Background { get; }

    /*
    example:

    #..#.
    #....
    ##..#
    ..#..
    ..###
    */
    public static Day20Image Create(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var set = new HashSet<(int X, int Y)>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                var character = line[x];
                if (character == '#')
                {
                    set.Add((x, y));
                }
            }
        }

        return new Day20Image(set, '.');
    }
}