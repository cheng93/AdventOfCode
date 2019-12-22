using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2019.Day18
{
    public class Day18Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var points = new Dictionary<Point, char>();
            var queue = new Queue<(Point Point, char Parent, int Depth, HashSet<Point> Path)>();
            var parents = new Dictionary<char, HashSet<char>>();
            var depth = new Dictionary<Point, int>();
            var paths = new Dictionary<char, HashSet<Point>>();
            var allKeys = new Dictionary<char, Point>();
            var traversed = new HashSet<Point>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var point = new Point(j, i);
                    var character = line[j];
                    points[point] = character;

                    if (character == '@')
                    {
                        paths[character] = new HashSet<Point>();
                        paths[character].Add(point);
                        allKeys[character] = point;
                        depth[point] = 0;
                        parents[character] = new HashSet<char>(new[] { character });
                        queue.Enqueue((point, character, 0, paths[character]));
                        traversed.Add(point);
                    }
                }
            }

            var sizes = new[]
            {
                new Size(0, 1),
                new Size(1, 0),
                new Size(0, -1),
                new Size(-1, 0)
            };

            while (queue.Any())
            {
                var current = queue.Dequeue();
                var parent = current.Parent;

                var character = points[current.Point];
                if (char.IsLetter(character))
                {
                    parents[character] = new HashSet<char>(parents[parent].Concat(new[] { character }));
                    paths[character] = current.Path;
                    parent = character;
                    if (char.IsLower(character))
                    {
                        allKeys[character] = current.Point;
                    }
                }
                depth[current.Point] = current.Depth;
                for (var i = 0; i < sizes.Length; i++)
                {
                    var point = Point.Add(current.Point, sizes[i]);
                    if (points[point] == '#' || traversed.Contains(point))
                    {
                        continue;
                    }

                    traversed.Add(point);
                    var path = new HashSet<Point>(current.Path);
                    path.Add(point);
                    queue.Enqueue((point, parent, current.Depth + 1, path));
                }
            }

            var visited = new Dictionary<(HashSet<char> Keys, char Key), int>(new PuzzleOneVisitedComparer());
            var allKeysSet = new HashSet<char>(allKeys.Keys);
            var emptyPointSet = new HashSet<Point>(points.Where(x => x.Value == '.').Select(x => x.Key));
            var min = int.MaxValue;
            var dQueue = new Queue<(char Key, int Length, HashSet<char> Keys)>();
            dQueue.Enqueue(('@', 0, new HashSet<char>(new[] { '@' })));
            while (dQueue.Any())
            {
                var current = dQueue.Dequeue();
                if (allKeysSet.SetEquals(current.Keys))
                {
                    min = Math.Min(min, current.Length);
                    continue;
                }

                if (visited.ContainsKey((current.Keys, current.Key)))
                {
                    if (current.Length >= visited[(current.Keys, current.Key)])
                    {
                        continue;
                    }
                }

                visited[(current.Keys, current.Key)] = current.Length;

                var neighbours = GetNeighbours(current.Keys);
                foreach (var neighbour in neighbours)
                {
                    var commonParent = paths[current.Key]
                        .Intersect(paths[neighbour])
                        .OrderByDescending(x => depth[x])
                        .First();

                    var distance = Math.Abs(depth[allKeys[neighbour]] - depth[commonParent])
                        + Math.Abs(depth[allKeys[current.Key]] - depth[commonParent]);

                    if (commonParent == allKeys['@'])
                    {
                        var movedStart = Point.Add(allKeys[current.Key], new Size(-commonParent.X, -commonParent.Y));
                        var movedEnd = Point.Add(allKeys[neighbour], new Size(-commonParent.X, -commonParent.Y));
                        if (movedStart.X != 0 && movedEnd.X != 0 && movedStart.Y != 0 && movedEnd.Y != 0)
                        {
                            var x = (Math.Sign(movedStart.X) + Math.Sign(movedEnd.X)) / 2;
                            var y = (Math.Sign(movedStart.Y) + Math.Sign(movedEnd.Y)) / 2;
                            var p = new HashSet<Point>();
                            p.Add(Point.Add(commonParent, new Size(x, y)));
                            p.Add(Point.Add(commonParent, new Size(y, x)));
                            p.Add(Point.Add(commonParent, new Size(-y, -x)));

                            if (p.Count == 3 && p.IsSubsetOf(emptyPointSet))
                            {
                                distance -= 2;
                            }
                        }
                    }

                    var keys = new HashSet<char>(current.Keys);
                    keys.Add(neighbour);

                    dQueue.Enqueue((neighbour, current.Length + distance, keys));
                }
            }

            IEnumerable<char> GetNeighbours(HashSet<char> keys)
            {
                return parents
                    .Where(x => char.IsLower(x.Key)
                        && !keys.Contains(x.Key)
                        && x.Value
                            .Where(char.IsUpper)
                            .All(v => keys.Contains(char.ToLower(v)))
                        && x.Value
                            .Where(v => char.IsLower(v) && v != x.Key)
                            .All(v => keys.Contains(v)))
                    .Select(x => x.Key);
            }

            return min;
        }

        public int PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var points = new Dictionary<Point, char>();
            var queue = new Queue<(Point Point, char Parent, int Depth, HashSet<Point> Path)>();
            var parents = new Dictionary<char, HashSet<char>>();
            var depth = new Dictionary<Point, int>();
            var paths = new Dictionary<char, HashSet<Point>>();
            var allKeys = new Dictionary<char, Point>();
            var traversed = new HashSet<Point>();
            var roots = new HashSet<char>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    var point = new Point(j, i);
                    var character = line[j];
                    points[point] = character;

                    if (character == '@')
                    {
                        var id = char.Parse(paths.Count.ToString());
                        points[point] = id;
                        paths[id] = new HashSet<Point>();
                        paths[id].Add(point);
                        allKeys[id] = point;
                        depth[point] = 0;
                        parents[id] = new HashSet<char>(new[] { id });
                        roots.Add(id);
                        queue.Enqueue((point, id, 0, paths[id]));
                        traversed.Add(point);
                    }
                }
            }

            var sizes = new[]
            {
                new Size(0, 1),
                new Size(1, 0),
                new Size(0, -1),
                new Size(-1, 0)
            };

            while (queue.Any())
            {
                var current = queue.Dequeue();
                var parent = current.Parent;

                var character = points[current.Point];
                if (char.IsLetter(character))
                {
                    parents[character] = new HashSet<char>(parents[parent].Concat(new[] { character }));
                    paths[character] = current.Path;
                    parent = character;
                    if (char.IsLower(character))
                    {
                        allKeys[character] = current.Point;
                    }
                }
                depth[current.Point] = current.Depth;
                for (var i = 0; i < sizes.Length; i++)
                {
                    var point = Point.Add(current.Point, sizes[i]);
                    if (points[point] == '#' || traversed.Contains(point))
                    {
                        continue;
                    }

                    traversed.Add(point);
                    var path = new HashSet<Point>(current.Path);
                    path.Add(point);
                    queue.Enqueue((point, parent, current.Depth + 1, path));
                }
            }

            var visited = new Dictionary<(HashSet<char> Keys, Dictionary<char, char> Robots), int>(new PuzzleTwoVisitedComparer());
            var allKeysSet = new HashSet<char>(allKeys.Keys);
            var min = int.MaxValue;
            var dQueue = new Queue<(int Length, HashSet<char> Keys, Dictionary<char, char> Robots)>();
            var robots = roots.ToDictionary(x => x, x => x);
            dQueue.Enqueue((0, new HashSet<char>(new[] { '0', '1', '2', '3' }), new Dictionary<char, char>(robots)));
            while (dQueue.Any())
            {
                var current = dQueue.Dequeue();
                if (allKeysSet.SetEquals(current.Keys))
                {
                    min = Math.Min(min, current.Length);
                    continue;
                }

                if (visited.ContainsKey((current.Keys, current.Robots)))
                {
                    if (current.Length >= visited[(current.Keys, current.Robots)])
                    {
                        continue;
                    }
                }

                visited[(current.Keys, current.Robots)] = current.Length;

                var neighbours = GetNeighbours(current.Keys);
                foreach (var neighbour in neighbours)
                {
                    var newRobots = new Dictionary<char, char>(current.Robots);
                    var robot = parents[neighbour].Intersect(roots).First();
                    var robotKey = current.Robots[robot];

                    var commonParent = paths[robotKey]
                        .Intersect(paths[neighbour])
                        .OrderByDescending(x => depth[x])
                        .FirstOrDefault();

                    var distance = Math.Abs(depth[allKeys[robotKey]] - depth[commonParent])
                        + Math.Abs(depth[allKeys[neighbour]] - depth[commonParent]);

                    newRobots[robot] = neighbour;

                    var keys = new HashSet<char>(current.Keys);
                    keys.Add(neighbour);

                    dQueue.Enqueue((current.Length + distance, keys, newRobots));
                }
            }

            IEnumerable<char> GetNeighbours(HashSet<char> keys)
            {
                return parents
                    .Where(x => char.IsLower(x.Key)
                        && !keys.Contains(x.Key)
                        && x.Value
                            .Where(char.IsUpper)
                            .All(v => keys.Contains(char.ToLower(v)))
                        && x.Value
                            .Where(v => char.IsLower(v) && v != x.Key)
                            .All(v => keys.Contains(v)))
                    .Select(x => x.Key);
            }

            return min;
        }

        private class PuzzleOneVisitedComparer : IEqualityComparer<(HashSet<char> Keys, char Key)>
        {
            public bool Equals((HashSet<char> Keys, char Key) x, (HashSet<char> Keys, char Key) y)
            {
                return x.Keys.SetEquals(y.Keys) && x.Key == y.Key;
            }

            public int GetHashCode((HashSet<char> Keys, char Key) obj)
            {
                return obj.Key.GetHashCode() + obj.Keys.Sum(x => x.GetHashCode() ^ 23);
            }
        }

        private class PuzzleTwoVisitedComparer : IEqualityComparer<(HashSet<char> Keys, Dictionary<char, char> Robots)>
        {
            public bool Equals((HashSet<char> Keys, Dictionary<char, char> Robots) x, (HashSet<char> Keys, Dictionary<char, char> Robots) y)
            {
                return x.Keys.SetEquals(y.Keys) && x.Robots.Keys.All(k => x.Robots[k] == y.Robots[k]);
            }

            public int GetHashCode((HashSet<char> Keys, Dictionary<char, char> Robots) obj)
            {
                unchecked
                {
                    var hash = int.MinValue;
                    foreach (var r in obj.Robots)
                    {
                        hash += r.GetHashCode() ^ 23;
                    }
                    foreach (var k in obj.Keys)
                    {
                        hash += k.GetHashCode() ^ 23;
                    }

                    return hash;
                }
            }
        }
    }
}