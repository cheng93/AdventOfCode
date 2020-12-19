using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day19
{
    public class Day19Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day19.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day19Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day19.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day19Solver().PuzzleTwo(input).ToString();
        }
    }
}