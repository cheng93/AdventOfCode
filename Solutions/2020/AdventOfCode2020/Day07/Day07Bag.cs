using System.Collections.Generic;

namespace AdventOfCode2020.Day07
{
    public class Day07Bag
    {
        /* 
        Input
        light red bags contain 1 bright white bag, 2 muted yellow bags.
        faded blue bags contain no other bags.
        */
        public Day07Bag(string input)
        {
            var splits = input.Split(" contain ");
            this.Name = string.Join(" ", splits[0].Split(" ")[0..^1]);

            var contains = new List<(string, int)>();

            if (splits[1] != "no other bags.")
            {
                var containSplits = splits[1].Split(", ");
                foreach (var containSplit in containSplits)
                {
                    var bagSplit = containSplit.Split(" ");
                    var amount = int.Parse(bagSplit[0]);

                    var bag = string.Join(" ", bagSplit[1..^1]);
                    contains.Add((bag, amount));
                }
            }

            this.Contains = contains;
        }

        public string Name { get; }

        public IEnumerable<(string Name, int Amount)> Contains { get; }
    }
}