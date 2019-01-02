namespace AdventOfCode2018.Day23
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day23Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var nanobots = input.Select(x => new Day23Nanobot(x));

            Day23Nanobot strongest = null;
            foreach (var nanobot in nanobots)
            {
                if (strongest == null || strongest.Radius < nanobot.Radius)
                {
                    strongest = nanobot;
                }
            }

            return nanobots
                .Where(x => ManhattanDistance(strongest.Position, x.Position) <= strongest.Radius)
                .Count();
        }

        public int PuzzleTwo(IEnumerable<string> input)
        {
            var nanobots = input.Select(x => new Day23Nanobot(x));

            var maxRadius = nanobots
                .Select(x => Math.Abs(x.Position.X) + Math.Abs(x.Position.Y) + Math.Abs(x.Position.Z))
                .Max() * 3;

            var queue = new Queue<Node>();
            queue.Enqueue(new Node((0, 0, 0), maxRadius, nanobots));

            var radiusCounts = new Dictionary<int, int>();
            var radiusPositions = new Dictionary<int, HashSet<(int X, int Y, int Z)>>();
            var positionNode = new Dictionary<(int X, int Y, int Z), Node>();

            var maxNanobots = int.MinValue;
            var minDistance = int.MaxValue;

            while (queue.Any())
            {
                var node = queue.Dequeue();
                if (node.Radius <= 3)
                {
                    var points = new List<(int X, int Y, int Z)>();
                    for (var i = -1; i < 2; i++)
                    {
                        for (var j = -1; j < 2; j++)
                        {
                            for (var k = -1; k < 2; k++)
                            {
                                points.Add((node.Position.X + i, node.Position.Y + j, node.Position.Z + k));
                            }
                        }
                    }

                    foreach (var point in points)
                    {
                        var count = 0;
                        foreach (var nanobot in node.Nanobots)
                        {
                            if (ManhattanDistance(point, nanobot.Position) <= nanobot.Radius)
                            {
                                count++;
                            }
                        }

                        if (count > maxNanobots)
                        {
                            maxNanobots = count;
                            var distance = ManhattanDistance((0, 0, 0), point);
                            minDistance = distance;
                        }
                        else if (count == maxNanobots)
                        {
                            var distance = ManhattanDistance((0, 0, 0), point);
                            minDistance = Math.Min(minDistance, distance);
                        }
                    }
                }
                else
                {
                    var plane = node.Radius / 3;
                    var modifier = plane / 2 + (plane % 2 != 0 ? 1 : 0);
                    var radius = modifier * 3;

                    if (!radiusPositions.ContainsKey(radius))
                    {
                        radiusCounts[radius] = int.MinValue;
                        radiusPositions[radius] = new HashSet<(int X, int Y, int Z)>();
                    }

                    var ones = new[] { -1, 1 };

                    for (var i = 0; i < 2; i++)
                    {
                        for (var j = 0; j < 2; j++)
                        {
                            for (var k = 0; k < 2; k++)
                            {
                                var x = node.Position.X + ones[i] * modifier;
                                var y = node.Position.Y + ones[j] * modifier;
                                var z = node.Position.Z + ones[k] * modifier;

                                var position = (x: x, Y: y, Z: z);

                                var newNanobots = new List<Day23Nanobot>();
                                foreach (var nanobot in node.Nanobots)
                                {
                                    if (nanobot.Radius + radius >= ManhattanDistance(nanobot.Position, position))
                                    {
                                        newNanobots.Add(nanobot);
                                    }
                                }

                                if (newNanobots.Count > radiusCounts[radius])
                                {
                                    radiusCounts[radius] = newNanobots.Count;
                                    radiusPositions[radius].Clear();
                                }
                                if (newNanobots.Count == radiusCounts[radius])
                                {
                                    radiusPositions[radius].Add(position);
                                    positionNode[position] = new Node(position, radius, newNanobots);
                                }
                            }
                        }
                    }

                    if (!queue.Any())
                    {
                        foreach (var position in radiusPositions[radius])
                        {
                            queue.Enqueue(positionNode[position]);
                        }
                    }
                }
            }

            return minDistance;
        }

        private class Node
        {
            public (int X, int Y, int Z) Position { get; }

            public int Radius { get; }

            public ICollection<Day23Nanobot> Nanobots { get; set; }

            public Node((int X, int Y, int Z) position, int radius, IEnumerable<Day23Nanobot> nanobots)
            {
                this.Position = position;
                this.Radius = radius;
                this.Nanobots = nanobots.ToList();
            }
        }

        private static int ManhattanDistance((int X, int Y, int Z) a, (int X, int Y, int Z) b)
            => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) + Math.Abs(a.Z - b.Z);
    }
}