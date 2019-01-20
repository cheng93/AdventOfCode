namespace AdventOfCode2016.Day01
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day01Puzzle : Puzzle
    {
        private const string resource = "AdventOfCode2016.Day01.Input.txt";

        public async override Task<string> PuzzleOne()
        {
            var input = await this.ReadResource(resource);

            return new Day01Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var input = await this.ReadResource(resource);

            return new Day01Solver().PuzzleTwo(input).ToString();
        }
    }
}