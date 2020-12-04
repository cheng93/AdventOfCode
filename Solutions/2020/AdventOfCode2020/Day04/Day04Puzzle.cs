using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day04
{
    public class Day04Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day04.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day04Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day04.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day04Solver().PuzzleTwo(input).ToString();
        }
    }
}