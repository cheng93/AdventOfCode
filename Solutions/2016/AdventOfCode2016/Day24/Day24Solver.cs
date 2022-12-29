namespace AdventOfCode2016.Day24;

public class Day24Solver
{
    public static int PuzzleOne(string input) => Solve(input, false);

    public static int PuzzleTwo(string input) => Solve(input, true);

    private static int Solve(string input, bool returnToStart)
    {
        var lines = input.Split(Environment.NewLine).ToArray(); ;
        var map = new HashSet<(int X, int Y)>();
        var wires = new Dictionary<(int X, int Y), int>();
        var paths = new Dictionary<int, Dictionary<int, int>>();

        for (var j = 0; j < lines.Length; j++)
        {
            var line = lines[j];
            for (var i = 0; i < line.Length; i++)
            {
                var character = line[i];
                if (character == '#')
                {
                    continue;
                }

                var point = (i, j);
                map.Add(point);
                if (int.TryParse(character.ToString(), out var parsed))
                {
                    wires[point] = parsed;
                    paths[parsed] = new Dictionary<int, int>();
                }
            }
        }

        Explore();
        return Dfs();

        void Explore()
        {
            var directions = new (int X, int Y)[]
            {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1),
            };

            foreach (var wire in wires)
            {
                var root = wire.Key;
                var visited = new HashSet<(int X, int Y)>();
                visited.Add(root);
                var queue = new Queue<((int X, int Y) Point, int Time)>();
                queue.Enqueue((root, 0));

                while (queue.Any())
                {
                    var (point, time) = queue.Dequeue();
                    if (wires.TryGetValue(point, out var destination))
                    {
                        paths[wire.Value][destination] = time;
                    }

                    foreach (var direction in directions)
                    {
                        var neighbour = (point.X + direction.X, point.Y + direction.Y);
                        if (!visited.Contains(neighbour) && map.Contains(neighbour))
                        {
                            visited.Add(neighbour);
                            queue.Enqueue((neighbour, time + 1));
                        }
                    }
                }
            }
        }

        int Dfs()
        {
            var min = int.MaxValue;
            var stack = new Stack<(HashSet<int> Visited, int Wire, int Time)>();
            stack.Push((new HashSet<int> { 0 }, 0, 0));
            while (stack.Any())
            {
                var (visited, wire, time) = stack.Pop();
                if (visited.Count == wires.Count)
                {
                    if (returnToStart)
                    {
                        time += paths[wire][0];
                    }
                    min = Math.Min(min, time);
                    continue;
                }

                foreach (var neighbour in wires.Values)
                {
                    if (!visited.Contains(neighbour))
                    {
                        var newVisited = new HashSet<int>(visited);
                        newVisited.Add(neighbour);
                        stack.Push((newVisited, neighbour, time + paths[wire][neighbour]));
                    }
                }
            }

            return min;
        }
    }
}