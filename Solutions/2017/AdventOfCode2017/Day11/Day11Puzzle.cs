namespace AdventOfCode2017.Day11
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day11Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day11.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day11Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day11.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day11Solver().PuzzleTwo(input).ToString();
        }
    }
}