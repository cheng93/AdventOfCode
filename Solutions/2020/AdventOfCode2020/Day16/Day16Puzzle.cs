using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day16
{
    public class Day16Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day16.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day16Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day16.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day16Solver().PuzzleTwo(input).ToString();
        }
    }
}