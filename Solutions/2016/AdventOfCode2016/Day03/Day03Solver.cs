namespace AdventOfCode2016.Day03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day03Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var count = 0;

            foreach (var line in lines)
            {
                var splits = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var a = splits[0];
                var b = splits[1];
                var c = splits[2];

                if (IsTriangle(a, b, c))
                {
                    count++;
                }
            }

            return count;
        }

        public int PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var count = 0;

            var queue = new Queue<int[]>();

            for (var i = 0; i < lines.Length; i++)
            {
                var splits = lines[i].Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                queue.Enqueue(splits);

                if (i % 3 == 2)
                {

                    var lengthsList = Enumerable.Range(0, 3)
                        .Select(x => new List<int>())
                        .ToArray();

                    while (queue.Any())
                    {
                        var row = queue.Dequeue();
                        for (var j = 0; j < 3; j++)
                        {
                            lengthsList[j].Add(row[j]);
                        }
                    }

                    foreach (var lengths in lengthsList)
                    {
                        var a = lengths[0];
                        var b = lengths[1];
                        var c = lengths[2];

                        if (IsTriangle(a, b, c))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private static bool IsTriangle(int a, int b, int c)
            => a + b > c && a + c > b && b + c > a;
    }
}