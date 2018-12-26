namespace AdventOfCode2018.Day21
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day21Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day21.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day21Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day21.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day21Solver().PuzzleTwo(input).ToString();
        }
    }
}