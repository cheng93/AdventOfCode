namespace AdventOfCode2017.Day01
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day01Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day01.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day01Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day01.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day01Solver().PuzzleTwo(input).ToString();
        }
    }
}