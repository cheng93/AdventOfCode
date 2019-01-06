namespace AdventOfCode2017.Day22
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day22Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day22.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day22Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day22.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day22Solver().PuzzleTwo(input).ToString();
        }
    }
}