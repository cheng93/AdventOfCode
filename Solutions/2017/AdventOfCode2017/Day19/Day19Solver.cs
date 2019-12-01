namespace AdventOfCode2017.Day19
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class Day19Solver
    {
        public string PuzzleOne(string input) => Solve(input).Letters;

        public int PuzzleTwo(string input) => Solve(input).Steps;

        private static (string Letters, int Steps) Solve(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var grid = new Dictionary<Point, char>();

            var queue = new Queue<Point>();

            for (var j = 0; j < lines.Length; j++)
            {
                var line = lines[j];
                for (var i = 0; i < line.Length; i++)
                {
                    if (line[i] == ' ')
                    {
                        continue;
                    }

                    var point = new Point(i, j);
                    grid[point] = line[i];

                    if (j == 0)
                    {
                        queue.Enqueue(point);
                    }
                }
            }

            var direction = 2;

            var sizes = new[]
            {
                new Size(0, -1),
                new Size(1, 0),
                new Size(0, 1),
                new Size(-1, 0)
            };

            var sb = new StringBuilder();
            var steps = 0;

            while (queue.Any())
            {
                var point = queue.Dequeue();
                var character = grid[point];

                if (char.IsLetter(character))
                {
                    sb.Append(character);
                }

                Point next = default;
                if (character == '+')
                {
                    foreach (var i in new[] { 1, 3 })
                    {
                        var potentialDirection = (direction + i) % 4;
                        next = Point.Add(point, sizes[potentialDirection]);
                        if (grid.ContainsKey(next))
                        {
                            direction = potentialDirection;
                            break;
                        }
                    }
                }
                else
                {
                    next = Point.Add(point, sizes[direction]);
                }

                if (grid.ContainsKey(next))
                {
                    queue.Enqueue(next);
                }
                steps++;
            }

            return (sb.ToString(), steps);
        }
    }
}