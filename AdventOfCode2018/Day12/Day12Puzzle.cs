namespace AdventOfCode2018.Day12
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day12Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day12.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day12Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day12.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day12Solver().PuzzleTwo(input).ToString();
        }
    }
}