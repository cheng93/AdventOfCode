namespace AdventOfCode2017.Day16
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day16Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day16.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day16Solver().PuzzleOne(input, 16);
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day16.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day16Solver().PuzzleTwo(input, 16);
        }
    }
}