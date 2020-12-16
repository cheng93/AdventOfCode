using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day16
{
    public class Day16Rule
    {
        // class: 1-3 or 5-7
        // departure location: 26-404 or 427-951
        public Day16Rule(string input)
        {
            var splits = input.Split(": ");

            this.Name = splits[0];

            var ranges = new List<(int Min, int Max)>();
            var rangeSplits = splits[1].Split(" or ");
            foreach (var rangeSplit in rangeSplits)
            {
                var minMax = rangeSplit
                    .Split('-')
                    .Select(int.Parse)
                    .ToArray();

                ranges.Add((minMax[0], minMax[1]));
            }

            this.Ranges = ranges;
        }

        public string Name { get; }

        public IEnumerable<(int Min, int Max)> Ranges { get; }
    }
}