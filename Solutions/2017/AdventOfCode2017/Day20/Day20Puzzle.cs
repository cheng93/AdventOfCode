namespace AdventOfCode2017.Day20
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day20Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day20.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day20Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day20.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day20Solver().PuzzleTwo(input).ToString();
        }
    }
}