using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IntCode;

namespace AdventOfCode2019.Day02
{
    public class Day02MachineSolver
    {
        public string PuzzleOne(IEnumerable<int> input)
        {
            var program = input.ToArray();
            var machine = new Machine(program.Select(x => (long)x), Enumerable.Empty<int>());
            machine.Run().ToList();

            return string.Join(',', machine.Memory);
        }
    }
}