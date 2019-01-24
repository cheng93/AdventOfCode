namespace AdventOfCode2016.Day03
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day03Puzzle : Puzzle
    {
        private const string resource = "AdventOfCode2016.Day03.Input.txt";

        public async override Task<string> PuzzleOne()
        {
            var input = await this.ReadResource(resource);

            return new Day03Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var input = await this.ReadResource(resource);

            return new Day03Solver().PuzzleTwo(input).ToString();
        }
    }
}