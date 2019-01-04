namespace AdventOfCode2017.Day18
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day18Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day18.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day18Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day18.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day18Solver().PuzzleTwo(input).ToString();
        }
    }
}