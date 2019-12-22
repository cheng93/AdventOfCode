using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day20
{
    public class Day20Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day20Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day20Solver().PuzzleTwo(input).ToString();
        }

        private async Task<string> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day20.PuzzleOne.txt"));
        }
    }
}