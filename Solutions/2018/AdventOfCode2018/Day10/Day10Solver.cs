namespace AdventOfCode2018.Day10
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day10Solver
    {
        public int PuzzleOne(IEnumerable<string> input, out IEnumerable<Point> positions)
        {
            var points = input.Select(x => new Day10Point(x));

            var iterations = 0;
            var iterationSize = 0;

            do
            {
                var minY = int.MaxValue;
                var maxY = int.MinValue;
                var minX = int.MaxValue;
                var maxX = int.MinValue;

                foreach (var point in points)
                {
                    if (point.Move(iterations).X > maxX) maxX = point.Move(iterations).X;
                    if (point.Move(iterations).X < minX) minX = point.Move(iterations).X;
                    if (point.Move(iterations).Y > maxY) maxY = point.Move(iterations).Y;
                    if (point.Move(iterations).Y < minY) minY = point.Move(iterations).Y;
                }

                var height = maxY - minY;
                var width = maxX - minX;

                iterationSize = height / 100;
                if (iterationSize == 0)
                {
                    iterationSize += 1;
                }

                var previousHeight = int.MaxValue;
                var previousWidth = int.MaxValue;

                while (true)
                {
                    minY = int.MaxValue;
                    maxY = int.MinValue;
                    minX = int.MaxValue;
                    maxX = int.MinValue;

                    foreach (var point in points)
                    {
                        if (point.Move(iterations).X > maxX) maxX = point.Move(iterations).X;
                        if (point.Move(iterations).X < minX) minX = point.Move(iterations).X;
                        if (point.Move(iterations).Y > maxY) maxY = point.Move(iterations).Y;
                        if (point.Move(iterations).Y < minY) minY = point.Move(iterations).Y;
                    }

                    height = maxY - minY;
                    width = maxX - minX;

                    if (height > previousHeight && width > previousWidth)
                    {
                        iterations -= iterationSize;
                        break;
                    }
                    else
                    {
                        previousHeight = height;
                        previousWidth = width;
                        iterations += iterationSize;
                    }
                }
            }
            while (iterationSize != 1);

            positions = points.Select(x => x.Move(iterations));
            return iterations;
        }
    }
}