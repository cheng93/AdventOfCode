namespace AdventOfCode2016.Day01
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day01Solver
    {
        public int PuzzleOne(string input) => Solve(input).Blocks;

        public int PuzzleTwo(string input) => Solve(input).First;

        private static (int Blocks, int First) Solve(string input)
        {
            var sequences = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day01Sequence(x));

            var sizes = new Size[]
            {
                new Size(0, 1),
                new Size(1, 0),
                new Size(0, -1),
                new Size(-1, 0)
            };

            var visited = new HashSet<Point>();

            var direction = 0;
            var point = new Point(0, 0);
            visited.Add(point);
            int? first = null;

            foreach (var sequence in sequences)
            {
                var change = sequence.IsLeft ? 3 : 1;
                direction = (direction + change) % 4;

                for (var i = 0; i < sequence.Blocks; i++)
                {
                    point = Point.Add(point, sizes[direction]);

                    var notVisited = visited.Add(point);
                    if (!notVisited && !first.HasValue)
                    {
                        first = ManhattanDistance(point, new Point(0, 0));
                    }
                }
            }

            return (ManhattanDistance(point, new Point(0, 0)), first ?? 0);
        }

        private static int ManhattanDistance(Point a, Point b)
            => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}