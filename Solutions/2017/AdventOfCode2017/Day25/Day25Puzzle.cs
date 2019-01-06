namespace AdventOfCode2017.Day25
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day25Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day25.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day25Solver().PuzzleOne(input).ToString();
        }

        public override Task<string> PuzzleTwo()
        {
            return Task.FromResult("Year 2017 Completed");
        }
    }
}