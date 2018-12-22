namespace AdventOfCode2018.Day22
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day22Solver
    {
        public int PuzzleOne(int depth, string target)
        {
            var splits = target.Split(',').Select(int.Parse).ToArray();
            var point = new Point(splits[0], splits[1]);

            var erosionLevels = new Dictionary<Point, int>();

            var sum = 0;

            for (var y = 0; y <= point.Y; y++)
            {
                for (var x = 0; x <= point.X; x++)
                {
                    var current = new Point(x, y);
                    var geologicalIndex = 0;
                    if (current == new Point(0, 0) || current == point)
                    {
                        geologicalIndex = 0;
                    }
                    else if (y == 0)
                    {
                        geologicalIndex = x * 16807;
                    }
                    else if (x == 0)
                    {
                        geologicalIndex = y * 48271;
                    }
                    else
                    {
                        var previousX = Point.Add(current, new Size(-1, 0));
                        var previousY = Point.Add(current, new Size(0, -1));
                        geologicalIndex = erosionLevels[previousX] * erosionLevels[previousY];
                    }

                    var erosionLevel = (geologicalIndex + depth) % 20183;
                    erosionLevels.Add(current, erosionLevel);

                    var type = erosionLevel % 3;

                    sum += type;
                }
            }

            return sum;
        }
        public int PuzzleTwo(int depth, string target)
        {
            var splits = target.Split(',').Select(int.Parse).ToArray();
            var point = new Point(splits[0], splits[1]);

            var erosionLevels = new Dictionary<Point, int>()
            {
                { new Point(0, 0), depth % 20183 },
                { point, depth % 20183 }
            };
            var types = new Dictionary<Point, int>()
            {
                { new Point(0, 0), 0 },
                { point, 0 },
            };

            var queue = new Queue<Node>();
            queue.Enqueue(new Node(0, new Point(0, 0), Gear.Torch, new List<Node>()));

            var visited = new HashSet<(Point, Gear)>();

            var typeGear = new Dictionary<int, Gear>()
            {
                { 0, Gear.Climbing | Gear.Torch },
                { 1, Gear.Climbing | Gear.Neither },
                { 2, Gear.Torch | Gear.Neither }
            };

            var slowQueue = new Dictionary<int, Queue<Node>>();

            while (queue.Any())
            {
                var node = queue.Dequeue();

                if (node.Point == point)
                {
                    if (node.Gear == Gear.Climbing)
                    {
                        var slowMinutes = node.Minutes + 7;
                        if (!slowQueue.ContainsKey(slowMinutes))
                        {
                            slowQueue.Add(slowMinutes, new Queue<Node>());
                        }
                        slowQueue[slowMinutes].Enqueue(new Node(slowMinutes, node.Point, Gear.Torch, node.Previous));
                    }
                    else
                    {
                        return node.Minutes;
                    }
                    continue;
                }

                Func<Node, (Point, Gear)> pointGear = (Node n) => (n.Point, n.Gear);

                if (visited.Contains(pointGear(node)))
                {
                    continue;
                }

                visited.Add(pointGear(node));

                if (slowQueue.ContainsKey(node.Minutes + 1))
                {
                    while (slowQueue[node.Minutes + 1].Any())
                    {
                        var slowNode = slowQueue[node.Minutes + 1].Dequeue();
                        if (!visited.Contains(pointGear(slowNode)))
                        {
                            queue.Enqueue(slowNode);
                        }
                    }
                    slowQueue.Remove(node.Minutes + 1);
                }

                foreach (var i in new[] { -1, 1 })
                {
                    foreach (var j in new[] { new Size(i, 0), new Size(0, i) })
                    {
                        var next = Point.Add(node.Point, j);
                        if (next.X < 0 || next.Y < 0)
                        {
                            continue;
                        }

                        var type = GetType(next, depth, types, erosionLevels);
                        if (node.Gear == (node.Gear & typeGear[type]))
                        {
                            var nextNode = new Node(node.Minutes + 1, next, node.Gear, node.Previous);
                            if (!visited.Contains(pointGear(nextNode)))
                            {
                                queue.Enqueue(nextNode);
                            }
                        }
                        else
                        {
                            var nodeType = GetType(node.Point, depth, types, erosionLevels);
                            var newGear = typeGear[nodeType] & typeGear[type];
                            var slowMinutes = node.Minutes + 8;
                            var slowNode = new Node(slowMinutes, next, newGear, node.Previous);

                            if (!visited.Contains(pointGear(slowNode)))
                            {
                                if (!slowQueue.ContainsKey(slowMinutes))
                                {
                                    slowQueue.Add(slowMinutes, new Queue<Node>());
                                }
                                slowQueue[slowMinutes].Enqueue(slowNode);
                            }
                        }
                    }
                }

                while (!queue.Any() && slowQueue.Keys.Any())
                {
                    var minKey = slowQueue.Keys.Min();
                    while (slowQueue[minKey].Any())
                    {
                        var slowNode = slowQueue[minKey].Dequeue();
                        if (!visited.Contains(pointGear(slowNode)))
                        {
                            queue.Enqueue(slowNode);
                        }
                    }
                    slowQueue.Remove(minKey);
                }
            }

            throw new Exception();
        }

        private static int GetErosionLevel(Point point, int depth, Dictionary<Point, int> erosionLevels)
        {
            if (erosionLevels.ContainsKey(point))
            {
                return erosionLevels[point];
            }

            var geologicalIndex = 0;
            if (point.Y == 0)
            {
                geologicalIndex = point.X * 16807;
            }
            else if (point.X == 0)
            {
                geologicalIndex = point.Y * 48271;
            }
            else
            {
                var previousX = Point.Add(point, new Size(-1, 0));
                var previousY = Point.Add(point, new Size(0, -1));
                geologicalIndex = GetErosionLevel(previousX, depth, erosionLevels) * GetErosionLevel(previousY, depth, erosionLevels);
            }

            var erosionLevel = (geologicalIndex + depth) % 20183;
            erosionLevels.Add(point, erosionLevel);

            return erosionLevel;
        }

        private static int GetType(Point point, int depth, Dictionary<Point, int> types, Dictionary<Point, int> erosionLevels)
        {
            if (types.ContainsKey(point))
            {
                return types[point];
            }

            var erosionLevel = GetErosionLevel(point, depth, erosionLevels);

            var type = erosionLevel % 3;
            types.Add(point, type);

            return type;
        }

        private class Node
        {
            public int Minutes { get; }

            public Point Point { get; }

            public Gear Gear { get; }

            public List<Node> Previous { get; }

            public Node(int minutes, Point point, Gear gear, List<Node> previous)
            {
                Minutes = minutes;
                Point = point;
                Gear = gear;
                Previous = previous.ToList();
                this.Previous.Add(this);
            }
        }

        [Flags]
        private enum Gear
        {
            Neither = 1,
            Torch = 2,
            Climbing = 4
        }
    }
}