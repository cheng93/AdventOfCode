namespace AdventOfCode2018.Day06
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day06Solver
    {
        public int PuzzleOne(IEnumerable<Point> input)
        {
            var edges = new List<Point>();
            var inside = new HashSet<Point>();
            var inputHash = new HashSet<Point>();

            foreach (var point in input)
            {
                inputHash.Add(point);
                if (edges.Count < 3)
                {
                    edges.Add(point);
                }
                else
                {
                    var isEdge = IsPointEdge(point, edges);
                    if (isEdge)
                    {
                        edges.Add(point);
                        var edgeToRemove = GetEdgeToRemove(edges);
                        if (edgeToRemove != null)
                        {
                            edges.Remove(edgeToRemove.Value);
                            inside.Add(edgeToRemove.Value);
                        }
                    }
                    else
                    {
                        inside.Add(point);
                    }
                }
            }

            var minX = edges.Min(x => x.X);
            var maxX = edges.Max(x => x.X);
            var minY = edges.Min(x => x.Y);
            var maxY = edges.Max(x => x.Y);

            var dict = new Dictionary<Point, int>();
            var max = 0;

            for (var i = minX; i <= maxX; i++)
            {
                for (var j = minY; j <= maxY; j++)
                {
                    var point = new Point(i, j);
                    var closestPoints = GetClosestPoints(point, inputHash);
                    if (closestPoints.Count == 1)
                    {
                        var closestPoint = closestPoints.First();
                        if (dict.ContainsKey(closestPoint))
                        {
                            dict[closestPoint] = dict[closestPoint] + 1;
                        }
                        else
                        {
                            dict.Add(closestPoint, 1);
                        }
                        if (!edges.Contains(closestPoint) && dict[closestPoint] > max)
                        {
                            max = dict[closestPoint];
                        }
                    }
                }
            }

            return max;
        }

        public int PuzzleTwo(IEnumerable<Point> input, int boundary)
        {
            var edges = new List<Point>();
            var inside = new HashSet<Point>();
            var inputHash = new HashSet<Point>();

            foreach (var point in input)
            {
                inputHash.Add(point);
                if (edges.Count < 3)
                {
                    edges.Add(point);
                }
                else
                {
                    var isEdge = IsPointEdge(point, edges);
                    if (isEdge)
                    {
                        edges.Add(point);
                        var edgeToRemove = GetEdgeToRemove(edges);
                        if (edgeToRemove != null)
                        {
                            edges.Remove(edgeToRemove.Value);
                            inside.Add(edgeToRemove.Value);
                        }
                    }
                    else
                    {
                        inside.Add(point);
                    }
                }
            }

            var minX = edges.Min(x => x.X);
            var maxX = edges.Max(x => x.X);
            var minY = edges.Min(x => x.Y);
            var maxY = edges.Max(x => x.Y);

            var count = 0;

            for (var i = minX; i <= maxX; i++)
            {
                for (var j = minY; j <= maxY; j++)
                {
                    var point = new Point(i, j);
                    if (input.Sum(x => GetManhattanDistance(point, x)) < boundary)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static List<Point> GetClosestPoints(Point point, HashSet<Point> points)
        {
            if (points.Contains(point))
            {
                return new List<Point>() { point };
            }
            var min = int.MaxValue;
            var result = new List<Point>();
            foreach (var p in points)
            {
                var distance = GetManhattanDistance(point, p);
                if (distance < min)
                {
                    min = distance;
                    result.Clear();
                    result.Add(p);
                }
                else if (distance == min)
                {
                    result.Add(p);
                }
            }

            return result;
        }

        private static int GetManhattanDistance(Point x, Point y)
        {
            return Math.Abs(x.X - y.X) + Math.Abs(x.Y - y.Y);
        }

        private static Point? GetEdgeToRemove(List<Point> edges)
        {
            foreach (var edge in edges)
            {
                if (!IsPointEdge(edge, edges.Where(x => x != edge).ToList()))
                {
                    return edge;
                }
            }
            return null;
        }

        private static bool IsPointEdge(Point point, List<Point> edges)
        {
            var minX = edges.Min(x => x.X);
            var maxX = edges.Max(x => x.X);
            var minY = edges.Min(x => x.Y);
            var maxY = edges.Max(x => x.Y);

            if (point.X < minX
                || point.X > maxX
                || point.Y < minY
                || point.Y > maxY)
            {
                return true;
            }

            var pointsLeft = edges.Where(x => x.X < point.X);
            var pointsRight = edges.Where(x => x.X > point.X);
            var pointsTop = edges.Where(x => x.Y < point.Y);
            var pointsBottom = edges.Where(x => x.Y < point.Y);

            return pointsLeft.All(x => Math.Abs(x.Y - point.Y) > Math.Abs(x.X - point.X))
                || pointsRight.All(x => Math.Abs(x.Y - point.Y) > Math.Abs(x.X - point.X))
                || pointsTop.All(x => Math.Abs(x.Y - point.Y) < Math.Abs(x.X - point.X))
                || pointsBottom.All(x => Math.Abs(x.Y - point.Y) < Math.Abs(x.X - point.X));
        }
    }
}