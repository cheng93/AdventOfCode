using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day06
{
    public class Day06Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day06.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day06Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day06.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day06Solver().PuzzleTwo(input).ToString();
        }
    }
}