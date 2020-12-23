using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day23
{
    public class Day23Puzzle : Puzzle
    {
        private const string Input = "467528193";

        public override Task<string> PuzzleOne()
        {
            return Task.FromResult(new Day23Solver().PuzzleOne(Input));
        }

        public override Task<string> PuzzleTwo()
        {
            return Task.FromResult(new Day23Solver().PuzzleTwo(Input).ToString());
        }
    }
}