namespace AdventOfCode2021.Day11;

public static class Day11Solver
{
    public static int PuzzleOne(string input) => Flashes(input).Take(100).Sum();

    public static int PuzzleTwo(string input)
        => Flashes(input)
            .Select((x, i) => new { Flashes = x, Step = i + 1 })
            .First(x => x.Flashes == 100)
            .Step;

    private static IEnumerable<int> Flashes(string input)
    {
        var lines = input.Split(Environment.NewLine).ToArray();
        var grid = new Dictionary<(int X, int Y), int>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                grid[(x, y)] = int.Parse(line[x].ToString());
            }
        }

        var adjs = new[] {
            (X: 1, Y: 0),
            (X: 1, Y: 1),
            (X: 1, Y: -1),
            (X: -1, Y: 0),
            (X: -1, Y: 1),
            (X: -1, Y: -1),
            (X: 0, Y: 1),
            (X: 0, Y: -1)
        };

        while (true)
        {
            foreach (var coord in grid.Keys)
            {
                grid[coord]++;
            }

            var flashed = new HashSet<(int X, int Y)>();
            foreach (var coord in grid.Where(x => x.Value > 9).Select(x => x.Key))
            {
                if (!flashed.Contains(coord))
                {
                    Bfs(coord);
                }
            }

            foreach (var coord in flashed)
            {
                grid[coord] = 0;
            }

            void Bfs((int X, int Y) root)
            {
                var queue = new Queue<(int X, int Y)>();
                queue.Enqueue(root);
                flashed.Add(root);

                while (queue.Any())
                {
                    var coord = queue.Dequeue();
                    foreach (var adj in adjs)
                    {
                        var next = (coord.X + adj.X, coord.Y + adj.Y);
                        if (!grid.ContainsKey(next))
                        {
                            continue;
                        }

                        grid[next]++;

                        if (grid[next] > 9 && !flashed.Contains(next))
                        {
                            queue.Enqueue(next);
                            flashed.Add(next);
                        }
                    }
                }
            }

            yield return flashed.Count;
        }
    }
}