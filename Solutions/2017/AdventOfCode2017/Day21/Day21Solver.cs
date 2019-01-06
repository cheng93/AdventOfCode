namespace AdventOfCode2017.Day21
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Day21Solver
    {
        public int PuzzleOne(string input, int iterations)
        {
            var rules = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day21Rule(x))
                .GroupBy(x => x.Size)
                .ToDictionary(
                    x => x.Key,
                    x => x
                        .SelectMany(y => y.Inputs
                            .Select(z => new
                            {
                                Input = z,
                                Output = y.Output
                            }))
                        .ToDictionary(y => y.Input, y => y.Output));

            var pattern = ".#./..#/###";

            for (var i = 0; i < iterations; i++)
            {
                var grid = pattern.Split('/');
                var divisor = grid.Length % 2 == 0 ? 2 : 3;
                var size = grid.Length / divisor;

                var rows = new List<string>();
                for (var j = 0; j < size; j++)
                {
                    var columns = new List<string>();
                    for (var k = 0; k < size; k++)
                    {
                        var list = new List<string>();
                        for (var l = 0; l < divisor; l++)
                        {
                            var builder = string.Empty;
                            for (var m = 0; m < divisor; m++)
                            {
                                builder += grid[j * divisor + l][k * divisor + m];
                            }
                            list.Add(builder);
                        }
                        columns.Add(rules[divisor][string.Join("/", list)]);
                    }

                    for (var k = 0; k < columns.Count; k++)
                    {
                        var splits = columns[k].Split('/');
                        for (var l = 0; l < splits.Length; l++)
                        {
                            var split = splits[l];
                            if (k == 0)
                            {
                                rows.Add(split);
                            }
                            else
                            {
                                rows[j * splits.Length + l] += split;
                            }
                        }
                    }
                }

                pattern = string.Join("/", rows);
            }

            return pattern.Count(x => x == '#');
        }
    }
}