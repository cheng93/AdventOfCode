namespace AdventOfCode2016.Day02
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day02Puzzle : Puzzle
    {
        private const string resource = "AdventOfCode2016.Day02.Input.txt";

        public async override Task<string> PuzzleOne()
        {
            var input = await this.ReadResource(resource);

            return new Day02Solver().PuzzleOne(input);
        }

        public async override Task<string> PuzzleTwo()
        {
            var input = await this.ReadResource(resource);

            return new Day02Solver().PuzzleTwo(input);
        }
    }
}