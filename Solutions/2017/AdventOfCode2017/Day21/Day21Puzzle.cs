namespace AdventOfCode2017.Day21
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day21Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day21.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day21Solver().PuzzleOne(input, 5).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day21.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day21Solver().PuzzleOne(input, 18).ToString();
        }
    }
}