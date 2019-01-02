namespace AdventOfCode2017.Day06
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day06Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day06.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day06Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day06.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day06Solver().PuzzleTwo(input).ToString();
        }
    }
}