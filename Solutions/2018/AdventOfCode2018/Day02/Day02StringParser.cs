
namespace AdventOfCode2018.Day02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day02StringParser
    {
        public Day02String Parse(string input)
        {
            var lookup = input
                .Select(x => x)
                .GroupBy(x => x)
                .ToLookup(x => x.Count());

            return new Day02String
            {
                HasTwo = lookup.Contains(2),
                HasThree = lookup.Contains(3)
            };
        }
    }
}