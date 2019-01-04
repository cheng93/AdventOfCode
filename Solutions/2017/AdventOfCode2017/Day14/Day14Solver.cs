namespace AdventOfCode2017.Day14
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class Day14Solver
    {
        public int PuzzleOne(string input)
        {
            var knotHashAlgorithm = new Day14KnotHashAlgorithm();

            var sum = 0;

            for (var i = 0; i < 128; i++)
            {
                var hashInput = $"{input}-{i}";
                var knotHash = knotHashAlgorithm.Convert(hashInput);

                var sb = new StringBuilder();
                foreach (var letter in knotHash)
                {
                    var binary = Convert.ToString(Convert.ToInt32(letter.ToString(), 16), 2).PadLeft(4, '0');
                    sb.Append(binary);
                }

                var binaryString = sb.ToString();
                sum += binaryString.Count(x => x == '1');
            }

            return sum;
        }

        public int PuzzleTwo(string input)
        {
            var knotHashAlgorithm = new Day14KnotHashAlgorithm();

            var grid = new Dictionary<Point, bool>();

            var queue = new Queue<Point>();

            for (var i = 0; i < 128; i++)
            {
                var hashInput = $"{input}-{i}";
                var knotHash = knotHashAlgorithm.Convert(hashInput);

                var sb = new StringBuilder();
                foreach (var letter in knotHash)
                {
                    var binary = Convert.ToString(Convert.ToInt32(letter.ToString(), 16), 2).PadLeft(4, '0');
                    sb.Append(binary);
                }

                var binaryString = sb.ToString();
                for (var j = 0; j < binaryString.Length; j++)
                {
                    var letter = binaryString[j];
                    var isUsed = letter == '1';
                    var point = new Point(j, i);
                    grid[point] = isUsed;
                    if (isUsed)
                    {
                        queue.Enqueue(point);
                    }
                }
            }

            var visited = new HashSet<Point>();
            var groups = 0;

            while (queue.Any())
            {
                var point = queue.Dequeue();
                while (visited.Contains(point))
                {
                    if (queue.Any())
                    {
                        point = queue.Dequeue();
                    }
                    else
                    {
                        return groups;
                    }
                }

                var regionQueue = new Queue<Point>();
                regionQueue.Enqueue(point);
                visited.Add(point);

                while (regionQueue.Any())
                {
                    var region = regionQueue.Dequeue();
                    foreach (var j in new[] { 1, -1 })
                    {
                        foreach (var size in new[] { new Size(j, 0), new Size(0, j) })
                        {
                            var adjacent = Point.Add(region, size);

                            if (grid.ContainsKey(adjacent) && grid[adjacent] && !visited.Contains(adjacent))
                            {
                                regionQueue.Enqueue(adjacent);
                                visited.Add(adjacent);
                            }
                        }
                    }
                }

                groups++;
            }

            throw new Exception();
        }
    }
}