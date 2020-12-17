using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day17
{
    public class Day17Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day17.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day17Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day17.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day17Solver().PuzzleTwo(input).ToString();
        }
    }
}