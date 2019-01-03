namespace AdventOfCode2017.Day08
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day08Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day08.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day08Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day08.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day08Solver().PuzzleTwo(input).ToString();
        }
    }
}