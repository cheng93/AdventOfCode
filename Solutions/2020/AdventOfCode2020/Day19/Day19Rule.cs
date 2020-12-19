using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day19
{
    public class Day19Rule
    {
        /*
        Input:
        0: 1 2
        1: "a"
        */
        public Day19Rule(string input)
        {
            var splits = input.Split(": ");
            this.Id = int.Parse(splits[0]);

            if (splits[1].Contains('"'))
            {
                this.Character = splits[1][1];
                this.SubRules = new List<IEnumerable<int>>();
            }
            else
            {
                var ruleSplits = splits[1].Split(" | ");
                this.SubRules = ruleSplits
                    .Select(x => x
                        .Split(" ")
                        .Select(int.Parse)
                        .ToList());
            }
        }

        public int Id { get; }

        public char? Character { get; }

        public IEnumerable<IEnumerable<int>> SubRules { get; }
    }
}