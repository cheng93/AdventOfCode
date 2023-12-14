namespace AdventOfCode2023.Day11;

using Coord = (long X, long Y);

public class Day11Image
{
    public Day11Image(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var emptyColumns = new HashSet<int>(Enumerable.Range(0, lines[0].Length));
        xLength = emptyColumns.Count;
        var emptyRows = new HashSet<int>(Enumerable.Range(0, lines.Length));
        yLength = emptyRows.Count;
        var galaxies = new HashSet<Coord>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '#')
                {
                    galaxies.Add((x, y));
                    emptyColumns.Remove(x);
                    emptyRows.Remove(y);
                }
            }
        }

        Galaxies = galaxies;
        EmptyColumns = emptyColumns;
        EmptyRows = emptyRows;
    }

    public IEnumerable<Coord> Galaxies { get; }

    public IEnumerable<int> EmptyColumns { get; }

    public IEnumerable<int> EmptyRows { get; }

    public IEnumerable<Coord> Expand(long factor)
    {
        var galaxies = new HashSet<Coord>();

        var yOffset = 0L;
        for (var y = 0; y < yLength; y++)
        {
            var xOffset = 0L;
            for (var x = 0; x < xLength; x++)
            {
                var coord = (x, y);
                if (EmptyColumns.Contains(x))
                {
                    xOffset += factor - 1;
                }
                if (Galaxies.Contains(coord))
                {
                    galaxies.Add((x + xOffset, y + yOffset));
                }
            }
            if (EmptyRows.Contains(y))
            {
                yOffset += factor - 1;
            }
        }

        return galaxies;
    }

    private readonly int xLength;

    private readonly int yLength;
}