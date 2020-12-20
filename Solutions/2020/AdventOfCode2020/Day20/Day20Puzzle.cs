using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day20
{
    public class Day20Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day20.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day20Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day20.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day20Solver().PuzzleTwo(input).ToString();
        }
    }
}