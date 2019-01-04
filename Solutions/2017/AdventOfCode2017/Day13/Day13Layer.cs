namespace AdventOfCode2017.Day13
{
    using System;
    using System.Linq;

    public class Day13Layer
    {
        public int Depth { get; }

        public int Range { get; }

        public Day13Layer(string input)
        {
            // Example input: 0: 3
            var splits = input
                .Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            this.Depth = splits[0];
            this.Range = splits[1];
        }
    }
}