using System;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode2019.Day03
{
    public class Day03Instruction
    {
        private readonly char direction;

        private readonly int distance;

        public Day03Instruction(string instruction)
        {
            this.direction = instruction[0];
            this.distance = int.Parse(instruction[1..]);
        }

        public IEnumerable<Point> GetPoints(Point point)
        {
            var size = this.direction switch
            {
                'U' => new Size(0, 1),
                'R' => new Size(1, 0),
                'D' => new Size(0, -1),
                'L' => new Size(-1, 0),
                _ => throw new InvalidOperationException()
            };

            for (var i = 0; i < this.distance; i++)
            {
                point = Point.Add(point, size);
                yield return point;
            }
        }
    }
}