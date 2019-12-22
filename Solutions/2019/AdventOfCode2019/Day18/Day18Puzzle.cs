using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day18
{
    public class Day18Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.ReadResource("AdventOfCode2019.Day18.PuzzleOne.txt");
            return new Day18Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.ReadResource("AdventOfCode2019.Day18.PuzzleTwo.txt");
            return new Day18Solver().PuzzleTwo(input).ToString();
        }
    }
}