using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day20
{
    public class Day20Tile
    {
        /*
        Input:
        Tile 3079:
        #.#.#####.
        .#..######
        ..#.......
        ######....
        ####.#..#.
        .#...#.##.
        #.#####.##
        ..#.###...
        ..#.......
        ..#.###...
        */
        public Day20Tile(string input)
        {
            var lines = input.Split(Environment.NewLine);

            this.Id = int.Parse(lines[0][5..^1]);

            var dict = new Dictionary<char, string>();
            dict['w'] = string.Empty;
            dict['e'] = string.Empty;
            for (var y = 0; y < lines[1..].Length; y++)
            {
                var line = lines[1..][y];

                if (y == 0)
                {
                    dict['n'] = line;
                }
                else if (y == lines[1..].Length - 1)
                {
                    dict['s'] = line;
                }
                for (var x = 0; x < line.Length; x++)
                {
                    if (x == 0)
                    {
                        dict['w'] += line[x];
                    }
                    else if (x == line.Length - 1)
                    {
                        dict['e'] += line[x];
                    }
                    else if (y != 0 && y != lines[1..].Length - 1)
                    {
                        this.Characters[(x - 1, y - 1)] = line[x];
                    }
                }
            }

            this.Orientation = new Day20Orientation(dict);
        }

        public int Id { get; }

        public Dictionary<(int X, int Y), char> Characters { get; } = new Dictionary<(int X, int Y), char>();

        public Day20Orientation Orientation { get; }
    }
}