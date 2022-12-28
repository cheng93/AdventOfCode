namespace AdventOfCode2016.Day22;

public class Day22Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var nodes = input
            .Skip(2)
            .Select(x => new Day22Node(x))
            .ToArray();

        var pairs = 0;
        for (var i = 0; i < nodes.Length - 1; i++)
        {
            var a = nodes[i];
            for (var j = i + 1; j < nodes.Length; j++)
            {
                var b = nodes[j];

                if (IsViablePair(a, b))
                {
                    pairs++;
                }
                if (IsViablePair(b, a))
                {
                    pairs++;
                }
            }
        }

        bool IsViablePair(Day22Node a, Day22Node b)
            => a.Used > 0 && a.Used <= b.Available;

        return pairs;
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var nodes = input
            .Skip(2)
            .Select(x => new Day22Node(x))
            .ToArray();
        var lookup = nodes.ToDictionary(x => x.Location, x => x);

        var empty = nodes.Single(x => x.Used == 0).Location;
        var yNodes = lookup.Keys
            .Where(x => x.Y == 0)
            .OrderBy(x => x.X)
            .ToArray();
        var goal = yNodes.First();
        var start = yNodes.Last();
        var steps = 0;

        for (var i = start.X; i > 0; i--)
        {
            var next = yNodes[i - 1];

            var emptyPath = FindEmpty();

            for (var j = 0; j < emptyPath.Count - 1; j++)
            {
                var emptyNode = lookup[emptyPath[j]];
                var movingNode = lookup[emptyPath[j + 1]];
                Move(movingNode, emptyNode);
            }
            Move(lookup[start], lookup[next]);

            void Move(Day22Node from, Day22Node to)
            {
                to.Used = from.Used;
                from.Used = 0;
                steps++;
            }

            empty = start;
            start = next;

            List<(int X, int Y)> FindEmpty()
            {
                var cameFrom = new Dictionary<(int X, int Y), (int X, int Y)>();
                var gScore = new Dictionary<(int X, int Y), int>();
                gScore[next] = 0;
                var queue = new PriorityQueue<(int X, int Y), int>();
                queue.Enqueue(next, 0);

                var directions = new (int X, int Y)[]
                {
                    (1, 0),
                    (0, 1),
                    (-1, 0),
                    (0, -1),
                };

                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    if (current == empty)
                    {
                        break;
                    }
                    var currentNode = lookup[current];

                    foreach (var direction in directions)
                    {
                        var neighbour = (current.X + direction.X, current.Y + direction.Y);
                        var newScore = gScore[current] + 1;
                        if (neighbour == start
                            || neighbour == next
                            || !lookup.TryGetValue(neighbour, out var neighbourNode)
                            || neighbourNode.Size < currentNode.Used)
                        {
                            continue;
                        }

                        if (!gScore.TryGetValue(neighbour, out var score) || newScore < score)
                        {
                            cameFrom[neighbour] = current;
                            gScore[neighbour] = newScore;
                            queue.Enqueue(neighbour, score + ManhattanDistance(neighbour, empty));
                        }

                        int ManhattanDistance((int X, int Y) a, (int X, int Y) b)
                            => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
                    }
                }

                var path = new List<(int X, int Y)>();
                path.Add(empty);
                while (cameFrom.TryGetValue(path.Last(), out var n))
                {
                    path.Add(n);
                }
                return path;
            }
        }

        return steps;
    }
}