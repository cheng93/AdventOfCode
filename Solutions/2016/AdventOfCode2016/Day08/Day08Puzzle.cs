namespace AdventOfCode2016.Day08
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day08Puzzle : Puzzle
    {
        private const string resource = "AdventOfCode2016.Day08.Input.txt";

        public async override Task<string> PuzzleOne()
        {
            var input = await this.ReadResource(resource);

            return new Day08Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var input = await this.ReadResource(resource);

            return new Day08Solver().PuzzleTwo(input);
        }
    }
}