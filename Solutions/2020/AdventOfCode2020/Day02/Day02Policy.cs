using System.Linq;

namespace AdventOfCode2020.Day02
{
    public class Day02Policy
    {
        // 1-3 a
        public Day02Policy(string input)
        {
            var splits = input.Split(" ");

            this.Letter = splits[1][0];

            var minMax = splits[0]
                .Split("-")
                .Select(int.Parse)
                .ToArray();

            this.Min = minMax[0];
            this.Max = minMax[1];
        }

        public char Letter { get; }
        public int Min { get; }
        public int Max { get; }
    }
}