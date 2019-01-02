namespace AdventOfCode2017.Day03
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Day03Solver
    {
        public int PuzzleOne(int input)
        {
            if (input == 1)
            {
                return 0;
            }

            var iteration = 1;
            var squared = 1;
            while (true)
            {
                squared = iteration * iteration;
                if (input <= squared)
                {
                    break;
                }
                iteration += 2;
            }

            var segment = iteration / 2;
            for (var i = 0; i < 8; i++)
            {
                var upper = squared - (i * segment);
                var lower = squared - ((i + 1) * segment);
                if (input > lower && input <= upper)
                {
                    if (i % 2 == 0)
                    {
                        return input - lower + segment;
                    }
                    else
                    {
                        return upper - input + segment;
                    }
                }
            }

            throw new Exception();
        }
        public int PuzzleTwo(int input)
        {
            var direction = 0;
            var moves = new[] { new Size(1, 0), new Size(0, 1), new Size(-1, 0), new Size(0, -1) };
            var grid = new Dictionary<Point, int>();

            var current = new Point(0, 0);
            grid[current] = 1;

            while (grid[current] <= input)
            {
                current = Point.Add(current, moves[direction]);
                var sum = 0;
                for (var i = -1; i < 2; i++)
                {
                    for (var j = -1; j < 2; j++)
                    {
                        if (i == 0 && j == 0) continue;

                        var adjacent = Point.Add(current, new Size(i, j));
                        if (grid.ContainsKey(adjacent))
                        {
                            sum += grid[adjacent];
                        }
                    }
                }

                grid[current] = sum;

                var next = Point.Add(current, moves[(direction + 1) % 4]);
                if (!grid.ContainsKey(next))
                {
                    direction = (direction + 1) % 4;
                }
            }

            return grid[current];
        }
    }
}