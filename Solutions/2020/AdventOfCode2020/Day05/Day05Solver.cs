using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day05
{
    public class Day05Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var scanner = new Day05Scanner();

            return input
                .Select(x => scanner.Scan(x))
                .Max();
        }

        public int PuzzleTwo(IEnumerable<string> input)
        {
            var scanner = new Day05Scanner();

            var min = int.MaxValue;
            var max = int.MinValue;
            var set = new HashSet<int>();

            foreach (var line in input)
            {
                var seatId = scanner.Scan(line);
                min = Math.Min(min, seatId);
                max = Math.Max(max, seatId);
                set.Add(seatId);
            }

            for (var i = min; i <= max; i++)
            {
                if (!set.Contains(i)
                    && set.Contains(i - 1)
                    && set.Contains(i + 1))
                {
                    return i;
                }
            }

            throw new System.Exception();
        }
    }
}