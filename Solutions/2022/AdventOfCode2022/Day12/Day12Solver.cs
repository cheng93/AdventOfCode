namespace AdventOfCode2022.Day12;

public static class Day12Solver
{
    public static int PuzzleOne(string input) => Walk(input, false);

    public static int PuzzleTwo(string input) => Walk(input, true);

    private static int Walk(string input, bool isTrail)
    {
        var lines = input.Split(Environment.NewLine).ToArray();
        var grid = new Dictionary<(int X, int Y), char>();

        var end = (X: 0, Y: 0);

        var queue = new Queue<((int X, int Y) Position, int Count)>();
        var visited = new HashSet<(int X, int Y)>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                var character = line[x];
                var elevation = character;
                if (character == 'S')
                {
                    elevation = 'a';
                }
                else if (character == 'E')
                {
                    end = (x, y);
                    elevation = 'z';
                }

                if (elevation == 'a')
                {
                    if (isTrail || character == 'S')
                    {
                        queue.Enqueue(((x, y), 0));
                        visited.Add((x, y));
                    }
                }

                grid.Add((x, y), elevation);
            }
        }

        while (queue.Any())
        {
            var current = queue.Dequeue();
            if (current.Position == end)
            {
                return current.Count;
            }

            foreach (var next in GetNext(current.Position))
            {
                if (!visited.Contains(next))
                {
                    visited.Add(next);
                    queue.Enqueue((next, current.Count + 1));
                }
            }
        }

        throw new Exception();

        IEnumerable<(int X, int Y)> GetNext((int X, int Y) position)
        {
            var elevation = grid[position];
            var directions = new (int X, int Y)[]
            {
                (1, 0),
                (0, 1),
                (-1, 0),
                (0, -1),
            };

            foreach (var direction in directions)
            {
                var next = (position.X + direction.X, position.Y + direction.Y);
                if (!grid.TryGetValue(next, out var e))
                {
                    continue;
                }

                if (e <= elevation + 1)
                {
                    yield return next;
                }
            }
        }
    }
}