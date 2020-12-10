using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day10
{
    public class Day10Solver
    {
        public int PuzzleOne(IEnumerable<int> input)
        {
            var sorted = input.OrderBy(x => x);
            var differences = new int[3];

            var prev = 0;
            foreach (var number in sorted)
            {
                differences[number - prev - 1]++;
                prev = number;
            }

            return differences[0] * (differences[2] + 1);

        }

        public long PuzzleTwo(IEnumerable<int> input)
        {
            var sorted = input.Concat(new[] { 0 }).OrderBy(x => x);
            var list = sorted.ToList();
            var lookup = list.ToDictionary(x => x, x => 0L);
            lookup[0] = 1;

            foreach (var number in list)
            {
                for (var i = 1; i <= 3; i++)
                {
                    var next = number + i;
                    if (lookup.ContainsKey(next))
                    {
                        lookup[next] += lookup[number];
                    }
                }
            }

            return lookup.Values.Last();
        }
    }
}