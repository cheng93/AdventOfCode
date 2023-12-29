namespace AdventOfCode2023.Day23;

using Coord = (int X, int Y);

public static class Day23Solver
{
    public static int PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var map = new Dictionary<Coord, char>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                map.Add((x, y), line[x]);
            }
        }

        Coord start = (1, 0);
        Coord end = (lines[0].Length - 2, lines.Length - 1);

        var modifiers = new Coord[]
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1)
        };
        var slopes = new[] { '>', 'v', '<', '^' };

        var stack = new Stack<(Coord Position, HashSet<Coord> Path)>();
        stack.Push((start, new HashSet<Coord> { start }));

        var longest = int.MinValue;

        while (stack.Any())
        {
            var (position, path) = stack.Pop();
            if (position == end)
            {
                longest = Math.Max(longest, path.Count);
                continue;
            }

            if (map[position] == '.')
            {
                foreach (var modifier in modifiers)
                {
                    Walk(modifier);
                }
            }
            else
            {
                var modifier = modifiers[Array.IndexOf(slopes, map[position])];
                Walk(modifier);
            }

            void Walk(Coord modifier)
            {
                var newPosition = (position.X + modifier.X, position.Y + modifier.Y);
                if (path.Contains(newPosition))
                {
                    return;
                }

                if (map.TryGetValue(newPosition, out var character) && character != '#')
                {
                    var newHashSet = path.ToHashSet();
                    newHashSet.Add(position);
                    stack.Push((newPosition, newHashSet));
                }
            }
        }

        return longest;
    }

    public static int PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var map = new Dictionary<Coord, char>();

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (var x = 0; x < line.Length; x++)
            {
                map.Add((x, y), line[x]);
            }
        }

        Coord start = (1, 0);
        Coord end = (lines[0].Length - 2, lines.Length - 1);

        var modifiers = new Coord[]
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1)
        };

        var graph = GetGraph();

        return LongestPath(start, new HashSet<Coord> { start });

        int LongestPath(Coord coord, HashSet<Coord> visited)
        {
            if (coord == end)
            {
                return 0;
            }

            var neighbours = graph[coord];
            var max = int.MinValue;
            foreach (var neighbour in neighbours)
            {
                var next = neighbour.Key;
                var length = neighbour.Value;
                if (visited.Contains(next))
                {
                    continue;
                }

                var newVisited = visited.ToHashSet();
                newVisited.Add(next);
                var distance = length + LongestPath(next, newVisited);
                max = Math.Max(max, distance);
            }

            return max;
        }

        Dictionary<Coord, Dictionary<Coord, int>> GetGraph()
        {
            var graph = new Dictionary<Coord, Dictionary<Coord, int>>();
            var seen = new HashSet<Coord>();

            var stack = new Stack<(Coord Position, Coord Source, int Steps)>();
            stack.Push((start, start, 0));

            while (stack.Any())
            {
                var (position, source, steps) = stack.Pop();

                var newPositions = modifiers
                    .Select(modifier => (position.X + modifier.X, position.Y + modifier.Y))
                    .Where(newPosition => map.TryGetValue(newPosition, out var character) && character != '#')
                    .ToArray();

                var isFork = newPositions.Length > 2;

                if (position == end)
                {
                    graph[source][end] = steps;
                    if (!graph.ContainsKey(end))
                    {
                        graph.Add(end, new());
                    }
                    graph[end][source] = steps;
                }

                if (isFork)
                {
                    if (!graph.ContainsKey(position))
                    {
                        graph.Add(position, new());
                    }

                    var currentDistance = 0;
                    graph[source].TryGetValue(position, out currentDistance);
                    graph[source][position] = Math.Max(currentDistance, steps);
                    graph[position][source] = Math.Max(currentDistance, steps);
                    source = position;
                    steps = 0;
                }

                if (!seen.Contains(position))
                {
                    seen.Add(position);
                    if (!graph.ContainsKey(position) && (isFork || position == start))
                    {
                        graph.Add(position, new());
                    }
                    foreach (var newPosition in newPositions)
                    {
                        if (newPosition != source)
                        {
                            stack.Push((newPosition, source, steps + 1));
                        }
                    }
                }
            }

            return graph;
        }
    }
}