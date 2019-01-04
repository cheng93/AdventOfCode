namespace AdventOfCode2017.Day12
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day12Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day12.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day12Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day12.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day12Solver().PuzzleTwo(input).ToString();
        }
    }
}