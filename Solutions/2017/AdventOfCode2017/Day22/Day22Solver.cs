namespace AdventOfCode2017.Day22
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Day22Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var middle = lines.Length / 2;

            var current = new Point(middle, middle);

            var infected = new HashSet<Point>();

            var direction = 0;
            var sizes = new[]
            {
                new Size(0, -1),
                new Size(1, 0),
                new Size(0, 1),
                new Size(-1, 0)
            };

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < lines.Length; j++)
                {
                    var point = new Point(j, i);
                    if (line[j] == '#')
                    {
                        infected.Add(point);
                    }
                }
            }

            var count = 0;
            for (var i = 0; i < 10000; i++)
            {
                var add = 0;
                if (infected.Contains(current))
                {
                    add = 1;
                    infected.Remove(current);
                }
                else
                {
                    add = 3;
                    infected.Add(current);
                    count++;
                }

                direction = (direction + add) % 4;

                current = Point.Add(current, sizes[direction]);
            }

            return count;
        }
        public int PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var middle = lines.Length / 2;

            var current = new Point(middle, middle);

            var states = new Dictionary<Point, int>();

            var direction = 0;
            var sizes = new[]
            {
                new Size(0, -1),
                new Size(1, 0),
                new Size(0, 1),
                new Size(-1, 0)
            };

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < lines.Length; j++)
                {
                    var point = new Point(j, i);
                    if (line[j] == '#')
                    {
                        states.Add(point, 1);
                    }
                }
            }

            var count = 0;
            for (var i = 0; i < 10000000; i++)
            {
                var add = 0;
                if (!states.ContainsKey(current))
                {
                    add = 3;
                    states.Add(current, 0);
                }
                else if (states[current] == 0)
                {
                    states[current]++;
                    count++;
                }
                else if (states[current] == 1)
                {
                    add = 1;
                    states[current]++;
                }
                else if (states[current] == 2)
                {
                    add = 2;
                    states.Remove(current);
                }

                direction = (direction + add) % 4;

                current = Point.Add(current, sizes[direction]);
            }

            return count;
        }
    }
}