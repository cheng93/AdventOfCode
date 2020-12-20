using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day20
{
    public class Day20Solver
    {
        public long PuzzleOne(string input)
        {
            var tiles = input
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(x => new Day20Tile(x))
                .ToDictionary(x => x.Id, x => x);

            var orientations = new Dictionary<(int X, int Y), (int Id, Day20Orientation Orientation)>();
            var first = tiles.Values.First();
            orientations[(0, 0)] = (first.Id, first.Orientation);
            var takenTiles = new HashSet<int>();
            takenTiles.Add(first.Id);
            var scanned = new HashSet<(int X, int Y)>();

            while (takenTiles.Count != tiles.Count)
            {
                var imageArea = orientations.First(x => !scanned.Contains(x.Key));
                var coord = imageArea.Key;
                var directions = new (int X, int Y)[]
                {
                    (0, 1), (1, 0), (0, -1), (-1, 0)
                };

                foreach (var direction in directions)
                {
                    var next = (X: coord.X + direction.X, Y: coord.Y + direction.Y);
                    if (orientations.ContainsKey(next))
                    {
                        continue;
                    }

                    var availableTiles = tiles.Values.Where(x => !takenTiles.Contains(x.Id));
                    foreach (var available in availableTiles)
                    {
                        var adjacent = new Dictionary<char, string>();
                        for (var i = 0; i < directions.Length; i++)
                        {
                            var a = (X: next.X + directions[i].X, Y: next.Y + directions[i].Y);
                            if (orientations.ContainsKey(a))
                            {
                                var o = orientations[a].Orientation;
                                var side = i switch
                                {
                                    0 => (Key: 'n', Value: o.South),
                                    1 => (Key: 'e', Value: o.West),
                                    2 => (Key: 's', Value: o.North),
                                    3 => (Key: 'w', Value: o.East),
                                    _ => throw new System.Exception()
                                };
                                adjacent.Add(side.Key, side.Value);
                            }
                        }

                        Day20Orientation orientation = null;
                        Day20Orientation test = available.Orientation;
                        for (var i = 0; i < 4; i++)
                        {
                            if (IsMatch(test))
                            {
                                orientation = test;
                                break;
                            }
                            test = test.Rotate();
                        }
                        if (orientation == null)
                        {
                            test = available.Orientation.Flip();
                            for (var i = 0; i < 4; i++)
                            {
                                if (IsMatch(test))
                                {
                                    orientation = test;
                                    break;
                                }
                                test = test.Rotate();
                            }
                        }

                        bool IsMatch(Day20Orientation o)
                        {
                            return
                                (!adjacent.TryGetValue('n', out var n) || n == o.North)
                                && (!adjacent.TryGetValue('e', out var e) || e == o.East)
                                && (!adjacent.TryGetValue('s', out var s) || s == o.South)
                                && (!adjacent.TryGetValue('w', out var w) || w == o.West);
                        }

                        if (orientation != null)
                        {
                            orientations[next] = (available.Id, orientation);
                            takenTiles.Add(available.Id);
                            break;
                        }
                    }
                }

                scanned.Add(coord);
            }

            var minX = orientations.Keys.Select(x => x.X).Min();
            var maxX = orientations.Keys.Select(x => x.X).Max();
            var minY = orientations.Keys.Select(x => x.Y).Min();
            var maxY = orientations.Keys.Select(x => x.Y).Max();

            return new[] { (minX, minY), (minX, maxY), (maxX, minY), (maxX, maxY) }
                .Aggregate(1L, (agg, cur) => agg * orientations[cur].Id);
        }

        public int PuzzleTwo(string input)
        {
            var tiles = input
                .Split($"{Environment.NewLine}{Environment.NewLine}")
                .Select(x => new Day20Tile(x))
                .ToDictionary(x => x.Id, x => x);

            var orientations = new Dictionary<(int X, int Y), (int Id, Day20Orientation Orientation)>();
            var image = new Dictionary<(int X, int Y), Dictionary<(int X, int Y), char>>();
            var first = tiles.Values.First();
            orientations[(0, 0)] = (first.Id, first.Orientation);
            image[(0, 0)] = first.Characters;
            var takenTiles = new HashSet<int>();
            takenTiles.Add(first.Id);
            var scanned = new HashSet<(int X, int Y)>();

            while (takenTiles.Count != tiles.Count)
            {
                var imageArea = orientations.First(x => !scanned.Contains(x.Key));
                var coord = imageArea.Key;
                var directions = new (int X, int Y)[]
                {
                    (0, 1), (1, 0), (0, -1), (-1, 0)
                };

                foreach (var direction in directions)
                {
                    var next = (X: coord.X + direction.X, Y: coord.Y + direction.Y);
                    if (orientations.ContainsKey(next))
                    {
                        continue;
                    }

                    var availableTiles = tiles.Values.Where(x => !takenTiles.Contains(x.Id));
                    foreach (var available in availableTiles)
                    {
                        var adjacent = new Dictionary<char, string>();
                        for (var i = 0; i < directions.Length; i++)
                        {
                            var a = (X: next.X + directions[i].X, Y: next.Y + directions[i].Y);
                            if (orientations.ContainsKey(a))
                            {
                                var o = orientations[a].Orientation;
                                var side = i switch
                                {
                                    0 => (Key: 'n', Value: o.South),
                                    1 => (Key: 'e', Value: o.West),
                                    2 => (Key: 's', Value: o.North),
                                    3 => (Key: 'w', Value: o.East),
                                    _ => throw new System.Exception()
                                };
                                adjacent.Add(side.Key, side.Value);
                            }
                        }

                        Day20Orientation orientation = null;
                        Day20Orientation test = available.Orientation;
                        var characters = available.Characters;
                        for (var i = 0; i < 4; i++)
                        {
                            if (IsMatch(test))
                            {
                                orientation = test;
                                break;
                            }
                            test = test.Rotate();
                            characters = characters.Rotate();
                        }
                        if (orientation == null)
                        {
                            test = available.Orientation.Flip();
                            characters = available.Characters.Flip();
                            for (var i = 0; i < 4; i++)
                            {
                                if (IsMatch(test))
                                {
                                    orientation = test;
                                    break;
                                }
                                test = test.Rotate();
                                characters = characters.Rotate();
                            }
                        }

                        bool IsMatch(Day20Orientation o)
                        {
                            return
                                (!adjacent.TryGetValue('n', out var n) || n == o.North)
                                && (!adjacent.TryGetValue('e', out var e) || e == o.East)
                                && (!adjacent.TryGetValue('s', out var s) || s == o.South)
                                && (!adjacent.TryGetValue('w', out var w) || w == o.West);
                        }

                        if (orientation != null)
                        {
                            orientations[next] = (available.Id, orientation);
                            image[next] = characters;
                            takenTiles.Add(available.Id);
                            break;
                        }
                    }
                }

                scanned.Add(coord);
            }


            var minX = orientations.Keys.Select(x => x.X).Min();
            var maxX = orientations.Keys.Select(x => x.X).Max();
            var minY = orientations.Keys.Select(x => x.Y).Min();
            var maxY = orientations.Keys.Select(x => x.Y).Max();

            var combined = new Dictionary<(int X, int Y), char>();

            var yMultiplier = 0;
            for (var y = maxY; y >= minY; y--)
            {
                var xMultiplier = 0;
                for (var x = minX; x <= maxX; x++)
                {
                    var multiplied = new Dictionary<(int X, int Y), char>();
                    var characters = image[(x, y)];

                    foreach (var kvp in characters)
                    {
                        multiplied[(kvp.Key.X + xMultiplier * 8, kvp.Key.Y + yMultiplier * 8)] = kvp.Value;
                    }

                    combined.Add(multiplied);
                    xMultiplier++;
                }
                yMultiplier++;
            }

            var seaMonster = new Day20SeaMonster();
            var attempt = combined;
            var set = new HashSet<(int X, int Y)>();

            for (var i = 0; i < 4; i++)
            {
                Scan(attempt);
                if (set.Count > 0)
                {
                    break;
                }
                attempt = attempt.Rotate();
            }
            if (set.Count == 0)
            {
                attempt = combined.Flip();
                for (var i = 0; i < 4; i++)
                {
                    Scan(attempt);
                    if (set.Count > 0)
                    {
                        break;
                    }
                    attempt = attempt.Rotate();
                }
            }

            void Scan(Dictionary<(int X, int Y), char> coords)
            {
                var maxX = coords.Keys.Select(x => x.X).Max();
                var maxY = coords.Keys.Select(x => x.Y).Max();

                for (var y = 0; y <= maxY; y++)
                {
                    for (var x = 0; x <= maxX; x++)
                    {
                        var find = seaMonster.Find((x, y));
                        if (find.All(i => coords.TryGetValue(i, out var c) && c == '#'))
                        {
                            set.UnionWith(find);
                        }
                    }
                }
            }

            return attempt.Count(x => !set.Contains(x.Key) && x.Value == '#');
        }
    }
}