namespace AdventOfCode2018.Day20
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day20Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day20.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day20Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day20.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day20Solver().PuzzleTwo(input, 1000).ToString();
        }
    }
}