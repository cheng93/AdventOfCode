using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day24
{
    public class Day24Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day24Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day24Solver().PuzzleTwo(input).ToString();
        }

        private async Task<string> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day24.PuzzleOne.txt"));
        }
    }
}