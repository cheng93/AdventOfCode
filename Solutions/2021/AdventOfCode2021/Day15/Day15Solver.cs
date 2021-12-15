namespace AdventOfCode2021.Day15;

public static class Day15Solver
{
    public static int PuzzleOne(string input)
    {
        var grid = new Dictionary<(int X, int Y), int>();

        var lines = input.Split(Environment.NewLine).ToArray();

        var source = (X: 0, Y: 0);
        var target = source;

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                var coord = (x, y);
                var value = int.Parse(line[x].ToString());
                grid[coord] = value;
                target = coord;
            }
        }

        return grid.Djikstra(source, target);
    }

    public static int PuzzleTwo(string input)
    {
        var grid = new Dictionary<(int X, int Y), int>();

        var lines = input.Split(Environment.NewLine).ToArray();

        var source = (X: 0, Y: 0);
        var target = source;

        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                for (var y = 0; y < lines.Length; y++)
                {
                    var line = lines[y];
                    for (var x = 0; x < line.Length; x++)
                    {
                        var bigX = j * line.Length + x;
                        var bigY = i * lines.Length + y;
                        var coord = (bigX, bigY);
                        var value = int.Parse(line[x].ToString());
                        value = (value + 8 + i + j) % 9 + 1;
                        grid[coord] = value;
                        target = coord;
                    }
                }
            }
        }

        return grid.Djikstra(source, target);
    }

    private static int Djikstra(
        this Dictionary<(int X, int Y), int> dict,
        (int X, int Y) source,
        (int X, int Y) target)
    {
        var dist = dict.ToDictionary(x => x.Key, x => int.MaxValue);
        var prev = dict.ToDictionary(x => x.Key, x => ((int X, int Y)?)null);
        dist[source] = 0;

        var queue = new PriorityQueue<(int X, int Y), int>();
        queue.Enqueue(source, 0);

        var adjs = new[] {
            (X: 1, Y: 0),
            (X: -1, Y: 0),
            (X: 0, Y: 1),
            (X: 0, Y: -1)
        };

        var inQueue = new HashSet<(int X, int Y)>();
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            inQueue.Remove(node);

            if (node == target)
            {
                break;
            }

            foreach (var adj in adjs)
            {
                var neighbour = (node.X + adj.X, node.Y + adj.Y);
                if (dict.TryGetValue(neighbour, out var neighbourValue))
                {
                    var newDist = dist[node] + neighbourValue;
                    if (newDist < dist[neighbour])
                    {
                        dist[neighbour] = newDist;
                        prev[neighbour] = node;
                        if (!inQueue.Contains(neighbour))
                        {
                            inQueue.Add(neighbour);
                            queue.Enqueue(neighbour, dist[neighbour]);
                        }
                    }
                }
            }
        }

        return dist[target];
    }
}