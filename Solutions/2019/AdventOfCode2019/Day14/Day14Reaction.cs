using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day14
{
    public class Day14Reaction
    {
        public Day14Reaction(string input)
        {
            // Example input: 7 A, 1 E => 1 FUEL
            var split = input.Split(" => ").ToArray();
            this.Input = split[0].Split(", ").Select(x => new Day14Chemical(x)).ToList();
            this.Output = new Day14Chemical(split[1]);
        }

        public ICollection<Day14Chemical> Input { get; }
        public Day14Chemical Output { get; }
    }
}