using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day12
{
    public class Day12Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var x = 0;
            var y = 0;
            var directions = new (int X, int Y)[]
            {
                (0, 1), (1, 0), (0, -1), (-1, 0)
            };
            var direction = 1;

            foreach (var line in input)
            {
                var action = line[0];
                var value = int.Parse(line[1..]);

                switch (action)
                {
                    case 'N':
                        y += value;
                        break;
                    case 'S':
                        y -= value;
                        break;
                    case 'E':
                        x += value;
                        break;
                    case 'W':
                        x -= value;
                        break;
                    case 'L':
                        direction = (direction + 4 - value / 90) % 4;
                        break;
                    case 'R':
                        direction = (direction + value / 90) % 4;
                        break;
                    case 'F':
                        x += directions[direction].X * value;
                        y += directions[direction].Y * value;
                        break;
                }
            }

            return ManhattanDistance((x, y), (0, 0));
        }

        public int PuzzleTwo(IEnumerable<string> input)
        {
            var x = 10;
            var y = 1;
            var shipX = 0;
            var shipY = 0;
            var multipliers = new (int X, int Y)[]
            {
                (1, 1), (1, -1), (-1, -1), (-1, 1)
            };

            foreach (var line in input)
            {
                var action = line[0];
                var value = int.Parse(line[1..]);

                switch (action)
                {
                    case 'N':
                        y += value;
                        break;
                    case 'S':
                        y -= value;
                        break;
                    case 'E':
                        x += value;
                        break;
                    case 'W':
                        x -= value;
                        break;
                    case 'L':
                        (x, y) = RotateWaypoint((4 - value / 90) % 4);
                        break;
                    case 'R':
                        (x, y) = RotateWaypoint((value / 90) % 4);
                        break;
                    case 'F':
                        shipX += value * x;
                        shipY += value * y;
                        break;
                }

                (int X, int Y) RotateWaypoint(int multiplier)
                {
                    var swapXY = multiplier % 2 == 1;
                    var relX = (swapXY ? y : x) * multipliers[multiplier].X;
                    var relY = (swapXY ? x : y) * multipliers[multiplier].Y;
                    return (relX, relY);
                }
            }

            return ManhattanDistance((shipX, shipY), (0, 0));
        }

        private static int ManhattanDistance((int X, int Y) a, (int X, int Y) b)
            => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}