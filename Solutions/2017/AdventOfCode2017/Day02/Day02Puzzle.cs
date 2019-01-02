namespace AdventOfCode2017.Day02
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day02Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day02.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day02Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day02.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day02Solver().PuzzleTwo(input).ToString();
        }
    }
}