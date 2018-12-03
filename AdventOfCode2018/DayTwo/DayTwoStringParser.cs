
namespace AdventOfCode2018.DayTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DayTwoStringParser
    {
        public DayTwoString Parse(string input)
        {
            var lookup = input
                .Select(x => x)
                .GroupBy(x => x)
                .ToLookup(x => x.Count());

            return new DayTwoString
            {
                HasTwo = lookup.Contains(2),
                HasThree = lookup.Contains(3)
            };
        }
    }
}