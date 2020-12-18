using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day18
{
    public class Day18Solver
    {
        public long PuzzleOne(IEnumerable<string> input)
        {
            return input
                .Select(x => new Day18Equation(x).Solve())
                .Sum();
        }

        public long PuzzleTwo(IEnumerable<string> input)
        {
            return input
                .Select(x => new Day18AdvancedEquation(x).Solve())
                .Sum();
        }
    }
}