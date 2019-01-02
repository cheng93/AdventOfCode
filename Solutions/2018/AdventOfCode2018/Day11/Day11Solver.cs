namespace AdventOfCode2018.Day11
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day11Solver
    {
        public Point PuzzleOne(int input)
        {
            var power = int.MinValue;
            Point point;
            for (var i = 1; i <= 298; i++)
            {
                for (var j = 1; j <= 298; j++)
                {
                    var gridPower = 0;

                    for (var a = 0; a < 3; a++)
                    {
                        var x = i + a;
                        for (var b = 0; b < 3; b++)
                        {
                            var y = j + b;
                            var rackId = x + 10;
                            var cellPower = rackId * y;
                            cellPower += input;
                            cellPower *= rackId;
                            cellPower = (cellPower / 100) % 10;
                            cellPower -= 5;
                            gridPower += cellPower;
                        }
                    }

                    if (gridPower > power)
                    {
                        power = gridPower;
                        point = new Point(i, j);
                    }

                }
            }

            return point;
        }
        public (Point Point, int Size) PuzzleTwo(int input)
        {
            var power = long.MinValue;
            Point point;
            int size = 0;

            var augmented = new Dictionary<Point, long>();

            for (var i = 1; i <= 300; i++)
            {
                for (var j = 1; j <= 300; j++)
                {
                    var rackId = i + 10;
                    var cellPower = rackId * j;
                    cellPower += input;
                    cellPower *= rackId;
                    cellPower = (cellPower / 100) % 10;
                    cellPower -= 5;

                    var currentPoint = new Point(i, j);
                    var previousX = i == 1 ? 0 : augmented[new Point(i - 1, j)];
                    var previousY = j == 1 ? 0 : augmented[new Point(i, j - 1)];
                    var previousXY = i == 1 || j == 1 ? 0 : augmented[new Point(i - 1, j - 1)];
                    augmented[currentPoint] = cellPower + previousX + previousY - previousXY;
                }
            }

            for (var i = 1; i <= 300; i++)
            {
                for (var j = 1; j <= 300; j++)
                {
                    var maxSize = Math.Min(300 - i, 300 - j);
                    for (var k = 0; k <= maxSize; k++)
                    {
                        var bottomRight = augmented[new Point(i + k, j + k)];
                        var bottomLeft = i == 1 ? 0 : augmented[new Point(i - 1, j + k)];
                        var topRight = j == 1 ? 0 : augmented[new Point(i + k, j - 1)];
                        var topLeft = i == 1 || j == 1 ? 0 : augmented[new Point(i - 1, j - 1)];

                        var gridPower = bottomRight - bottomLeft - topRight + topLeft;

                        if (gridPower > power)
                        {
                            power = gridPower;
                            point = new Point(i, j);
                            size = k + 1;
                        }
                    }
                }
            }



            return (point, size);
        }
    }
}