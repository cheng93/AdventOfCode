namespace AdventOfCode2017.Day23
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day23Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day23.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day23Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day23.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day23Solver().PuzzleTwo(input).ToString();
        }
    }
}