using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IntCode;

namespace AdventOfCode2019.Day09
{
    public class Day09MachineSolver
    {
        public IEnumerable<long> PuzzleOne(IEnumerable<long> input, long[] signals = null)
            => IntCode(input, signals ?? new[] { 1L });

        public long PuzzleTwo(IEnumerable<long> input, long[] signals = null)
            => IntCode(input, signals ?? new[] { 2L }).First();

        private static IEnumerable<long> IntCode(IEnumerable<long> input, long[] signals)
            => new Machine(input, signals.Select(x => (int)x)).Run();
    }
}