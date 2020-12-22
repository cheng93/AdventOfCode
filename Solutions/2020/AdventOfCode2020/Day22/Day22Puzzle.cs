using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day22
{
    public class Day22Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day22.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day22Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day22.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day22Solver().PuzzleTwo(input).ToString();
        }
    }
}