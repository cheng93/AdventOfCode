namespace AdventOfCode2015.Day03;

using Coord = (int X, int Y);

public static class Day03Solver
{
    public static int PuzzleOne(string input) => Solve(input, 1);

    public static int PuzzleTwo(string input) => Solve(input, 2);

    private static int Solve(string input, int count)
    {
        Coord origin = (0, 0);
        var visited = new HashSet<Coord>() { (0, 0) };
        var santas = Enumerable
            .Range(0, count)
            .Select(x => origin)
            .ToArray();

        for (var i = 0; i < input.Length; i++)
        {
            var mod = i % count;
            var santa = santas[mod];
            Coord modifier = input[i] switch
            {
                '^' => (0, 1),
                '>' => (1, 0),
                'v' => (0, -1),
                '<' => (-1, 0),
                _ => throw new Exception()
            };

            santas[mod] = (santa.X + modifier.X, santa.Y + modifier.Y);
            visited.Add(santas[mod]);
        }

        return visited.Count;
    }
}