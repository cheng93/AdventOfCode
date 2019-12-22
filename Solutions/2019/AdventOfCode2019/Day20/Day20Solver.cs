using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2019.Day20
{
    public class Day20Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var points = new Dictionary<Point, char>();
            var connections = new Dictionary<Point, Point>();

            var portals = new Dictionary<string, Point>();
            var portalPoints = new HashSet<Point>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var point = new Point(j, i);
                    var character = line[j];
                    if (character == ' ')
                    {
                        continue;
                    }
                    if (character == '#' || character == '.')
                    {
                        points[point] = character;
                    }
                    else if (char.IsUpper(character) && !portalPoints.Contains(point))
                    {
                        string portal;
                        Point step;
                        if (char.IsUpper(line[j + 1]))
                        {
                            portalPoints.Add(new Point(j + 1, i));
                            portal = $"{character}{line[j + 1]}";
                            step = j == 0
                                ? new Point(j + 2, i)
                                : line[j - 1] == '.'
                                    ? new Point(j - 1, i)
                                    : new Point(j + 2, i);
                        }
                        else
                        {
                            portalPoints.Add(new Point(j, i + 1));
                            var nextLine = lines[i + 1];
                            portal = $"{character}{nextLine[j]}";
                            step = i == 0
                                ? new Point(j, i + 2)
                                : lines[i - 1][j] == '.'
                                        ? new Point(j, i - 1)
                                        : new Point(j, i + 2);
                        }

                        if (portals.ContainsKey(portal))
                        {
                            connections[step] = portals[portal];
                            connections[portals[portal]] = step;
                            portals.Remove(portal);
                        }
                        else
                        {
                            portals[portal] = step;
                        }

                        portalPoints.Add(point);
                    }
                }
            }

            var start = portals["AA"];
            var end = portals["ZZ"];

            var traversed = new HashSet<Point>(new[] { start });
            var queue = new Queue<(Point Point, int Depth)>(new[] { (start, 0) });

            var sizes = new[]
            {
                new Size(0, -1),
                new Size(1, 0),
                new Size(0, 1),
                new Size(-1, 0),
            };

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (current.Point == end)
                {
                    return current.Depth;
                }

                traversed.Add(current.Point);
                for (var i = 0; i < sizes.Length; i++)
                {
                    var point = Point.Add(current.Point, sizes[i]);
                    if (points.ContainsKey(point) && !traversed.Contains(point) && points[point] == '.')
                    {
                        queue.Enqueue((point, current.Depth + 1));
                    }
                }
                if (connections.ContainsKey(current.Point) && !traversed.Contains(connections[current.Point]))
                {
                    queue.Enqueue((connections[current.Point], current.Depth + 1));
                }
            }

            throw new Exception();
        }


        public int PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var points = new Dictionary<Point, char>();
            var connections = new Dictionary<Point, Point>();

            var portals = new Dictionary<string, Point>();
            var portalPoints = new HashSet<Point>();

            var outer = new HashSet<Point>();
            var inner = new HashSet<Point>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var point = new Point(j, i);
                    var character = line[j];
                    if (character == ' ')
                    {
                        continue;
                    }
                    if (character == '#' || character == '.')
                    {
                        points[point] = character;
                    }
                    else if (char.IsUpper(character) && !portalPoints.Contains(point))
                    {
                        string portal;
                        Point step;
                        bool isOuter = false;
                        if (char.IsUpper(line[j + 1]))
                        {
                            portalPoints.Add(new Point(j + 1, i));
                            portal = $"{character}{line[j + 1]}";
                            step = j == 0
                                ? new Point(j + 2, i)
                                : line[j - 1] == '.'
                                    ? new Point(j - 1, i)
                                    : new Point(j + 2, i);
                            if (j == 0 || j == line.Length - 2)
                            {
                                isOuter = true;
                            }
                        }
                        else
                        {
                            portalPoints.Add(new Point(j, i + 1));
                            var nextLine = lines[i + 1];
                            portal = $"{character}{nextLine[j]}";
                            step = i == 0
                                ? new Point(j, i + 2)
                                : lines[i - 1][j] == '.'
                                        ? new Point(j, i - 1)
                                        : new Point(j, i + 2);
                            if (i == 0 || i == lines.Length - 2)
                            {
                                isOuter = true;
                            }
                        }

                        if (portals.ContainsKey(portal))
                        {
                            connections[step] = portals[portal];
                            connections[portals[portal]] = step;
                            portals.Remove(portal);
                        }
                        else
                        {
                            portals[portal] = step;
                        }

                        if (isOuter)
                        {
                            outer.Add(step);
                        }
                        else
                        {
                            inner.Add(step);
                        }

                        portalPoints.Add(point);
                    }
                }
            }

            var start = portals["AA"];
            var end = portals["ZZ"];

            var traversed = new HashSet<(Point Point, int Level)>(new[] { (start, 0) });
            var queue = new Queue<(Point Point, int Depth, int Level)>(new[] { (start, 0, 0) });

            var sizes = new[]
            {
                new Size(0, -1),
                new Size(1, 0),
                new Size(0, 1),
                new Size(-1, 0),
            };

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (current.Point == end && current.Level == 0)
                {
                    return current.Depth;
                }

                traversed.Add((current.Point, current.Level));
                for (var i = 0; i < sizes.Length; i++)
                {
                    var point = Point.Add(current.Point, sizes[i]);
                    if (points.ContainsKey(point) && !traversed.Contains((point, current.Level)) && points[point] == '.')
                    {
                        queue.Enqueue((point, current.Depth + 1, current.Level));
                    }
                }
                if (connections.ContainsKey(current.Point))
                {
                    var newLevel = current.Level
                        + (outer.Contains(current.Point) ? -1 : 1);

                    if (!traversed.Contains((connections[current.Point], newLevel)) && newLevel >= 0)
                    {
                        queue.Enqueue((connections[current.Point], current.Depth + 1, newLevel));
                    }
                }
            }

            throw new Exception();
        }
    }
}