namespace AdventOfCode2017.Day20
{
    using System.Linq;

    public class Day20Point
    {
        public long X { get; set; }

        public long Y { get; set; }

        public long Z { get; set; }

        public Day20Point(string input)
        {
            // Example input: -6,2,-16
            var splits = input
                .Split(',')
                .Select(long.Parse)
                .ToArray();

            this.X = splits[0];
            this.Y = splits[1];
            this.Z = splits[2];
        }
    }
}