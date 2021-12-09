namespace AdventOfCode2021.Day09;

public static class Day09Solver
{
    public static int PuzzleOne(IEnumerable<string> input) => Solve(input).RiskLevel;

    public static int PuzzleTwo(IEnumerable<string> input)
        => Solve(input).BasinSizes
            .OrderByDescending(x => x)
            .Take(3)
            .Aggregate(1, (agg, cur) => agg * cur);

    private static (int RiskLevel, IEnumerable<int> BasinSizes) Solve(IEnumerable<string> input)
    {
        var array = input.ToArray();
        var coords = new Dictionary<(int X, int Y), int>();

        for (var y = 0; y < array.Length; y++)
        {
            var line = array[y];
            for (var x = 0; x < line.Length; x++)
            {
                coords[(x, y)] = int.Parse(line[x].ToString());
            }
        }

        var riskLevel = 0;
        var lowest = new HashSet<(int X, int Y)>();
        var adjs = new[] { (X: 1, Y: 0), (X: -1, Y: 0), (X: 0, Y: 1), (X: 0, Y: -1) };

        foreach (var coord in coords.Keys)
        {
            var point = coords[coord];
            var isLowest = true;
            foreach (var adj in adjs)
            {
                if (coords.TryGetValue((coord.X + adj.X, coord.Y + adj.Y), out var adjPoint))
                {
                    if (adjPoint <= point)
                    {
                        isLowest = false;
                        break;
                    }
                }
            }

            if (isLowest)
            {
                riskLevel += point + 1;
                lowest.Add(coord);
            }
        }

        int Bfs((int X, int Y) root)
        {
            var queue = new Queue<(int X, int Y)>();
            var visited = new HashSet<(int X, int Y)> { root };
            queue.Enqueue(root);

            while (queue.Any())
            {
                var coord = queue.Dequeue();
                var value = coords[coord];
                foreach (var adj in adjs)
                {
                    var next = (coord.X + adj.X, coord.Y + adj.Y);

                    if (coords.TryGetValue(next, out var nextValue)
                        && nextValue != 9
                        && nextValue > value
                        && !visited.Contains(next))
                    {
                        queue.Enqueue(next);
                        visited.Add(next);
                    }
                }
            }


            return visited.Count;
        }

        return (riskLevel, lowest.Select(Bfs));
    }
}