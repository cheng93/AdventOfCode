namespace AdventOfCode2016.Day06
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day06Puzzle : Puzzle
    {
        private const string resource = "AdventOfCode2016.Day06.Input.txt";

        public async override Task<string> PuzzleOne()
        {
            var input = await this.ReadResource(resource);

            return new Day06Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var input = await this.ReadResource(resource);

            return new Day06Solver().PuzzleTwo(input).ToString();
        }
    }
}