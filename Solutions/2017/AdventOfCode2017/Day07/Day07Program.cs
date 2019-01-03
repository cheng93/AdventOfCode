namespace AdventOfCode2017.Day07
{
    using System;
    using System.Collections.Generic;

    public class Day07Program
    {
        public string Name { get; }

        public int Weight { get; }

        public HashSet<string> SubPrograms { get; } = new HashSet<string>();

        public Day07Program(string input)
        {
            // Example input:
            // pbga (66)
            // fwft (72) -> ktlj, cntj, xhth

            var splits = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

            var first = splits[0].Split(new[] { " (" }, StringSplitOptions.RemoveEmptyEntries);

            this.Name = first[0];
            this.Weight = int.Parse(first[1].Substring(0, first[1].Length - 1));

            if (splits.Length > 1)
            {
                var subPrograms = splits[1].Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                this.SubPrograms = new HashSet<string>(subPrograms);
            }
        }
    }
}