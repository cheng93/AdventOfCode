namespace AdventOfCode2017.Day02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day02Row
    {
        public IEnumerable<int> Numbers { get; }

        public Day02Row(string input)
        {
            // Example input: 5 1 9 5
            this.Numbers = Regex.Replace(input, "\\s+", ",")
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }
    }
}