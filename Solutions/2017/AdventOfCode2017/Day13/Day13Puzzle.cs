namespace AdventOfCode2017.Day13
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day13Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day13.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day13Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day13.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day13Solver().PuzzleTwo(input).ToString();
        }
    }
}