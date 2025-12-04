namespace AdventOfCode2025.Day04;

using Coord = (int X, int Y);

public static class Day04Solver
{
    public static int PuzzleOne(string input) => Solve(input, 1);

    public static int PuzzleTwo(string input) => Solve(input);

    private static int Solve(string input, int iterations = int.MaxValue)
    {
        var lines = input.Split(Environment.NewLine);
        var rolls = new HashSet<Coord>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                if (line[x] == '@')
                {
                    rolls.Add((x, y));
                }
            }
        }

        Coord[] directions =
        [
            (1, 0),
            (1, 1),
            (0, 1),
            (-1, 1),
            (-1, 0),
            (-1, -1),
            (0, -1),
            (1, -1),
        ];

        var total = 0;
        for (var i = 0; i < iterations; i++)
        {
            var remove = rolls
                .Where(c => directions.Count(d => rolls.Contains((d.X + c.X, d.Y + c.Y))) < 4)
                .ToArray();
            if (remove.Length == 0)
            {
                break;
            }

            total += remove.Length;
            rolls.RemoveWhere(r => remove.Contains(r));
        }

        return total;
    }
}