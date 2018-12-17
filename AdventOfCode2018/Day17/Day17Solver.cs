namespace AdventOfCode2018.Day17
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day17Solver
    {
        public int PuzzleOne(IEnumerable<string> input) => Solve(input).Tiles;
        public int PuzzleTwo(IEnumerable<string> input) => Solve(input).Rests;

        private static (int Tiles, int Rests) Solve(IEnumerable<string> input)
        {
            var veins = new HashSet<Point>();

            var minY = int.MaxValue;
            var maxY = int.MinValue;
            var minX = int.MaxValue;
            var maxX = int.MinValue;

            foreach (var line in input)
            {
                var scan = new Day17Scan(line);
                foreach (var point in scan.Points)
                {
                    veins.Add(point);
                    if (point.Y < minY) minY = point.Y;
                    if (point.Y > maxY) maxY = point.Y;
                    if (point.X < minX) minX = point.X;
                    if (point.X > maxX) maxX = point.X;
                }
            }

            var tiles = new HashSet<Point>();

            var initialPoint = new Point(500, Math.Max(1, minY));

            var queue = new Queue<Point>(new[] { initialPoint });
            var checkpoints = new Stack<Point>();
            var rest = new HashSet<Point>();

            while (queue.Any())
            {
                var point = queue.Dequeue();
                tiles.Add(point);

                var below = Point.Add(point, new Size(0, 1));
                if (!veins.Contains(below) && !rest.Contains(below))
                {
                    if (below.Y <= maxY)
                    {
                        queue.Enqueue(below);
                    }
                }
                else
                {
                    var lowerBound = (int?)null;
                    var upperBound = (int?)null;
                    for (var i = point.X; i >= minX; i--)
                    {
                        if (veins.Contains(new Point(i, point.Y)))
                        {
                            lowerBound = i;
                            break;
                        }
                    }
                    for (var i = point.X; i <= maxX; i++)
                    {
                        if (veins.Contains(new Point(i, point.Y)))
                        {
                            upperBound = i;
                            break;
                        }
                    }

                    var isRest = lowerBound.HasValue && upperBound.HasValue;

                    if (isRest)
                    {
                        for (var i = lowerBound + 1; i < upperBound; i++)
                        {
                            var check = new Point(i.Value, point.Y + 1);
                            if (!veins.Contains(check) && !rest.Contains(check))
                            {
                                isRest = false;
                                break;
                            }
                        }
                    }

                    if (isRest)
                    {
                        rest.Add(point);
                        var above = Point.Add(point, new Size(0, -1));
                        if (tiles.Contains(above))
                        {
                            checkpoints.Push(above);
                        }
                    }

                    foreach (var i in new[] { -1, 1 })
                    {
                        var side = Point.Add(point, new Size(i, 0));
                        if (!veins.Contains(side)
                            && ((!tiles.Contains(side) && !isRest)
                            || (!rest.Contains(side) && isRest)))
                        {
                            queue.Enqueue(side);
                        }
                    }
                }

                if (!queue.Any() && checkpoints.Any())
                {
                    queue.Enqueue(checkpoints.Pop());
                }
            }

            return (tiles.Count, rest.Count);
        }
    }
}