namespace AdventOfCode2016.Day07
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day07Puzzle : Puzzle
    {
        private const string resource = "AdventOfCode2016.Day07.Input.txt";

        public async override Task<string> PuzzleOne()
        {
            var input = await this.ReadResource(resource);

            return new Day07Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var input = await this.ReadResource(resource);

            return new Day07Solver().PuzzleTwo(input).ToString();
        }
    }
}