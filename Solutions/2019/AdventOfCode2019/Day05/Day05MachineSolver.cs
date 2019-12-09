using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IntCode;

namespace AdventOfCode2019.Day05
{
    public class Day05MachineSolver
    {
        public IEnumerable<int> PuzzleOne(IEnumerable<int> input, int systemId = 1) => Solve(input, systemId);

        public IEnumerable<int> PuzzleTwo(IEnumerable<int> input, int systemId = 5) => Solve(input, systemId);

        private static IEnumerable<int> Solve(IEnumerable<int> input, int systemId)
        {
            var program = input.ToArray();
            var machine = new Machine(program.Select(x => (long)x), new[] { systemId });
            return machine.Run().Select(x => (int)x);
        }
    }
}