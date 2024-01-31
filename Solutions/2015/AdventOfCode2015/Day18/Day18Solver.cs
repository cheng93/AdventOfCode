namespace AdventOfCode2015.Day18;

using Coord = (int X, int Y);

public static class Day18Solver
{
    public static int PuzzleOne(string input, int steps = 100)
    {
        var lines = input.Split(Environment.NewLine);
        var grid = new Dictionary<Coord, bool>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                grid.Add((x, y), line[x] == '#');
            }
        }

        var modifiers = new Coord[]
        {
            (1, 0),
            (1, 1),
            (0, 1),
            (-1, 1),
            (-1, 0),
            (-1, -1),
            (0, -1),
            (1, -1),
        };

        for (var i = 0; i < steps; i++)
        {
            var newGrid = new Dictionary<Coord, bool>();

            foreach (var (key, value) in grid)
            {
                var onNeighbours = modifiers
                    .Select(x => (key.X + x.X, key.Y + x.Y))
                    .Where(grid.ContainsKey)
                    .Count(x => grid[x]);

                var light = value
                    ? onNeighbours is 2 or 3
                    : onNeighbours is 3;
                newGrid[key] = light;
            }

            grid = newGrid;
        }

        return grid.Count(x => x.Value);
    }

    public static int PuzzleTwo(string input, int steps = 100)
    {
        var lines = input.Split(Environment.NewLine);
        var grid = new Dictionary<Coord, bool>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                grid.Add((x, y), line[x] == '#');
            }
        }

        var corners = new Coord[]
        {
            (0, 0),
            (lines.Length - 1, 0),
            (0, lines.Length - 1),
            (lines.Length - 1, lines.Length - 1),
        };

        foreach (var corner in corners)
        {
            grid[corner] = true;
        }

        var modifiers = new Coord[]
        {
            (1, 0),
            (1, 1),
            (0, 1),
            (-1, 1),
            (-1, 0),
            (-1, -1),
            (0, -1),
            (1, -1),
        };

        for (var i = 0; i < steps; i++)
        {
            var newGrid = new Dictionary<Coord, bool>();

            foreach (var (key, value) in grid)
            {
                if (corners.Contains(key))
                {
                    newGrid[key] = true;
                    continue;
                }
                var onNeighbours = modifiers
                    .Select(x => (key.X + x.X, key.Y + x.Y))
                    .Where(grid.ContainsKey)
                    .Count(x => grid[x]);

                var light = value
                    ? onNeighbours is 2 or 3
                    : onNeighbours is 3;
                newGrid[key] = light;
            }

            grid = newGrid;
        }

        return grid.Count(x => x.Value);
    }
}