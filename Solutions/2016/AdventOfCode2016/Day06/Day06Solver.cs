namespace AdventOfCode2016.Day06
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day06Solver
    {
        public string PuzzleOne(string input) => Solve(input).Most;

        public string PuzzleTwo(string input) => Solve(input).Least;

        private static (string Most, string Least) Solve(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var columns = new List<List<char>>();

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    if (i == 0)
                    {
                        columns.Add(new List<char>());
                    }

                    columns[j].Add(line[j]);
                }
            }

            var mostColumns = columns
                .Select(x => x
                    .GroupBy(y => y)
                    .OrderByDescending(y => y.Count())
                    .First()
                    .Key);

            var leastColumns = columns
                .Select(x => x
                    .GroupBy(y => y)
                    .OrderBy(y => y.Count())
                    .First()
                    .Key);

            return (string.Join("", mostColumns), string.Join("", leastColumns));
        }
    }
}