using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day24
{
    public class Day24Solver
    {
        private static readonly string[] Directions = new[] { "e", "se", "sw", "w", "nw", "ne" };

        public int PuzzleOne(IEnumerable<string> input)
        {
            var lookup = new Dictionary<string, bool>();

            foreach (var line in input)
            {
                var key = Reduce(line);
                if (lookup.TryGetValue(key, out var value))
                {
                    lookup[key] = !value;
                }
                else
                {
                    lookup[key] = true;
                }
            }

            return lookup.Values.Count(x => x);
        }

        public int PuzzleTwo(IEnumerable<string> input)
        {
            var lookup = new Dictionary<string, bool>();

            foreach (var line in input)
            {
                var key = Reduce(line);
                if (lookup.TryGetValue(key, out var value))
                {
                    lookup[key] = !value;
                }
                else
                {
                    lookup[key] = true;
                }
            }

            for (var i = 0; i < 100; i++)
            {
                var scanned = new HashSet<string>();
                var flip = new HashSet<string>();
                foreach (var kvp in lookup.Where(x => x.Value))
                {
                    var tiles = Directions.Concat(new[] { "" })
                        .Select(x => Reduce($"{kvp.Key}{x}"));

                    foreach (var tile in tiles)
                    {
                        if (scanned.Contains(tile))
                        {
                            continue;
                        }

                        var blacks = CountBlacks(tile);
                        if (lookup.TryGetValue(tile, out var value) && value)
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

                    int CountBlacks(string key)
                    {
                        return Directions
                            .Select(x => Reduce($"{key}{x}"))
                            .Count(x => lookup.TryGetValue(x, out var v) && v);
                    }
                }

                foreach (var f in flip)
                {
                    if (lookup.TryGetValue(f, out var value))
                    {
                        lookup[f] = !value;
                    }
                    else
                    {
                        lookup[f] = true;
                    }
                }
            }

            return lookup.Values.Count(x => x);
        }

        private string Reduce(string line)
        {
            var modifierLookup = new Dictionary<string, (string Minus, string Add)[]>()
            {
                { "e", new[] { ("w", null), ("sw", "se"), ("nw", "ne"), (null, "e") }},
                { "se", new[] { ("nw", null), ("w", "sw"), ("ne", "e"), (null, "se") }},
                { "sw", new[] { ("ne", null), ("e", "se"), ("nw", "w"), (null, "sw") }},
                { "w", new[] { ("e", null), ("se", "sw"), ("ne", "nw"), (null, "w") }},
                { "nw", new[] { ("se", null), ("e", "ne"), ("sw", "w"), (null, "nw") }},
                { "ne", new[] { ("sw", null), ("w", "nw"), ("se", "e"), (null, "ne") }},
            };

            var directionCount = Directions.ToDictionary(x => x, x => 0);

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

                var modifiers = modifierLookup[direction];
                foreach (var modifier in modifiers)
                {
                    if (modifier.Minus != null && directionCount[modifier.Minus] == 0)
                    {
                        continue;
                    }

                    if (modifier.Minus != null)
                    {
                        directionCount[modifier.Minus]--;
                    }
                    if (modifier.Add != null)
                    {
                        directionCount[modifier.Add]++;
                    }
                    break;
                }
            }


            var expanded = directionCount.Select(x => string.Join("", Enumerable.Repeat(x.Key, x.Value)));
            return string.Join("", expanded);
        }
    }
}