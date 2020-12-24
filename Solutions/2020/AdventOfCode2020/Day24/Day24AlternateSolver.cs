using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day24
{
    public class Day24AlternateSolver
    {
        private static readonly string[] Directions = new[] { "e", "se", "sw", "w", "nw", "ne" };

        public int PuzzleOne(IEnumerable<string> input)
        {
            var set = new HashSet<(int Q, int R)>();

            foreach (var line in input)
            {
                var coord = ToCoordinates(line);
                if (set.Contains(coord))
                {
                    set.Remove(coord);
                }
                else
                {
                    set.Add(coord);
                }
            }

            return set.Count;
        }

        public int PuzzleTwo(IEnumerable<string> input)
        {
            var set = new HashSet<(int Q, int R)>();

            foreach (var line in input)
            {
                var coord = ToCoordinates(line);
                if (set.Contains(coord))
                {
                    set.Remove(coord);
                }
                else
                {
                    set.Add(coord);
                }
            }

            for (var i = 0; i < 100; i++)
            {
                var scanned = new HashSet<(int Q, int R)>();
                var flip = new HashSet<(int Q, int R)>();
                foreach (var coord in set)
                {
                    var tiles = Directions
                        .Select(x => Move(coord, x))
                        .Concat(new[] { coord });

                    foreach (var tile in tiles)
                    {
                        if (scanned.Contains(tile))
                        {
                            continue;
                        }

                        var blacks = CountBlacks(tile);
                        if (set.Contains(tile))
                        {
                            if (blacks == 0 || blacks > 2)
                            {
                                flip.Add(tile);
                            }
                        }
                        else
                        {
                            if (blacks == 2)
                            {
                                flip.Add(tile);
                            }
                        }

                        scanned.Add(tile);
                    }

                    int CountBlacks((int Q, int R) key)
                    {
                        return Directions
                            .Select(x => Move(key, x))
                            .Count(x => set.Contains(x));
                    }
                }

                foreach (var coord in flip)
                {
                    if (set.Contains(coord))
                    {
                        set.Remove(coord);
                    }
                    else
                    {
                        set.Add(coord);
                    }
                }
            }

            return set.Count;
        }

        private (int Q, int R) Move((int Q, int R) initial, string direction)
        {
            var lookup = new Dictionary<string, (int Q, int R)>()
            {
                { "e", (1, 0) },
                { "se", (1, 1) },
                { "sw", (0, 1) },
                { "w", (-1, 0) },
                { "nw", (0, -1) },
                { "ne", (1, -1) },
            };

            var offset = lookup[direction];
            var qOffset = offset.Q - Math.Abs(offset.R) * (Math.Abs(initial.R) % 2 == 1 ? 0 : 1);

            return (initial.Q + qOffset, initial.R + offset.R);
        }

        private (int Q, int R) ToCoordinates(string line)
        {
            var tile = (Q: 0, R: 0);
            for (var i = 0; i < line.Length; i++)
            {
                var letter = line[i];
                string direction = null;
                if (letter == 's' || letter == 'n')
                {
                    i++;
                    direction = $"{letter}{line[i]}";
                }
                else
                {
                    direction = letter.ToString();
                }

                tile = Move(tile, direction);
            }

            return tile;
        }
    }
}