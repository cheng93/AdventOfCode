using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day01
{
    public class Day01Solver
    {
        public int PuzzleOne(IEnumerable<int> input)
            => input.Sum(x => (x / 3) - 2);

        public int PuzzleTwo(IEnumerable<int> input)
        {
            var sum = 0;

            foreach (var module in input)
            {
                var current = module;
                while (true)
                {
                    current = (current / 3) - 2;
                    if (current > 0)
                    {
                        sum += current;
                        continue;
                    }
                    break;
                }
            }

            return sum;
        }
    }
}