using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2019.Day24
{
    public class Day24Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var points = new Dictionary<Point, char>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    var point = new Point(j, i);

                    points[point] = character;
                }
            }

            var states = new List<HashSet<Point>>();
            var currentState = GetCurrentState();

            var sizes = new Size[]
            {
                new Size(0, -1),
                new Size(1, 0),
                new Size(0, 1),
                new Size(-1, 0)
            };

            while (states.All(s => !s.SetEquals(currentState)))
            {
                states.Add(currentState);

                var tiles = new Dictionary<Point, (bool IsBug, int Bugs)>();
                foreach (var point in points.Keys.ToList())
                {
                    var isBug = points[point] == '#';
                    var bugs = 0;
                    foreach (var size in sizes)
                    {
                        var newPoint = Point.Add(point, size);
                        if (points.TryGetValue(newPoint, out var character) && character == '#')
                        {
                            bugs++;
                        }
                    }

                    tiles[point] = (isBug, bugs);
                }

                foreach (var tile in tiles)
                {
                    var t = tile.Value;
                    if (t.IsBug && t.Bugs != 1)
                    {
                        points[tile.Key] = '.';
                    }
                    else if (!t.IsBug && (t.Bugs == 1 || t.Bugs == 2))
                    {
                        points[tile.Key] = '#';
                    }
                }

                currentState = GetCurrentState();
            }

            HashSet<Point> GetCurrentState() => new HashSet<Point>(points.Where(x => x.Value == '#').Select(x => x.Key));

            return currentState.Sum(x => (int)Math.Pow(2, x.Y * 5 + x.X));
        }

        public int PuzzleTwo(string input, int iterations = 200)
        {

            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var levels = new Dictionary<int, Dictionary<Point, char>>();
            levels[0] = GetNewLevel();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var character = line[j];
                    var point = new Point(j, i);

                    levels[0][point] = character;
                }
            }

            var sizes = new Size[]
            {
                new Size(0, -1),
                new Size(1, 0),
                new Size(0, 1),
                new Size(-1, 0)
            };

            for (var i = 0; i < iterations; i++)
            {
                var max = levels.Keys.Max();
                var min = levels.Keys.Min();

                levels[max + 1] = GetNewLevel();
                levels[min - 1] = GetNewLevel();

                var tiles = new List<(Point Point, int Level, bool IsBug, int Bugs)>();

                foreach (var level in levels)
                {
                    foreach (var point in level.Value.Keys.ToList())
                    {
                        if (point == new Point(2, 2))
                        {
                            continue;
                        }
                        var isBug = level.Value[point] == '#';
                        var bugs = 0;

                        var neighbours = GetNeighbours(level.Key, point);
                        foreach (var neighbour in neighbours)
                        {
                            if (levels.TryGetValue(neighbour.Level, out var l)
                                && l.TryGetValue(neighbour.Point, out var c) && c == '#')
                            {
                                bugs++;
                            }
                        }

                        tiles.Add((point, level.Key, isBug, bugs));
                    }
                }

                foreach (var tile in tiles)
                {
                    if (tile.IsBug && tile.Bugs != 1)
                    {
                        levels[tile.Level][tile.Point] = '.';
                    }
                    else if (!tile.IsBug && (tile.Bugs == 1 || tile.Bugs == 2))
                    {
                        levels[tile.Level][tile.Point] = '#';
                    }
                }
            }

            Dictionary<Point, char> GetNewLevel()
            {
                var points = new Dictionary<Point, char>();
                for (var i = 0; i < 5; i++)
                {
                    for (var j = 0; j < 5; j++)
                    {
                        var point = new Point(i, j);
                        points[point] = '.';

                    }
                }
                return points;
            }

            IEnumerable<(int Level, Point Point)> GetNeighbours(int level, Point point)
            {
                foreach (var size in sizes)
                {
                    var newPoint = Point.Add(point, size);
                    if (newPoint == new Point(2, 2))
                    {
                        var toAdd = size switch
                        {
                            { Width: 0, Height: -1 } => new Size(1, 0),
                            { Width: -1, Height: 0 } => new Size(0, 1),
                            { Width: 0, Height: 1 } => new Size(1, 0),
                            { Width: 1, Height: 0 } => new Size(0, 1),
                            _ => throw new Exception()
                        };

                        for (var i = 0; i < 5; i++)
                        {
                            var newLevelPoint = Point.Add(new Point(0, 0), toAdd * i);
                            if (size.Height < 0 || size.Width < 0)
                            {
                                newLevelPoint = Point.Add(newLevelPoint, new Size((size.Width + 5) % 5, (size.Height + 5) % 5));
                            }
                            yield return (level + 1, newLevelPoint);
                        }
                    }
                    else if (levels[level].ContainsKey(newPoint))
                    {
                        yield return (level, newPoint);
                    }
                    else
                    {
                        var newLevelPoint = Point.Add(new Point(2, 2), size);
                        yield return (level - 1, newLevelPoint);
                    }
                }
            }

            return levels.Values.Sum(x => x.Values.Count(y => y == '#'));
        }
    }
}