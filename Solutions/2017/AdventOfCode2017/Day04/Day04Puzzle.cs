namespace AdventOfCode2017.Day04
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day04Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day04.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day04Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day04.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day04Solver().PuzzleTwo(input).ToString();
        }
    }
}