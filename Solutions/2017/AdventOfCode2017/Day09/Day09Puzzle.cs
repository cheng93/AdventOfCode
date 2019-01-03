namespace AdventOfCode2017.Day09
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day09Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day09.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day09Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day09.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day09Solver().PuzzleTwo(input).ToString();
        }
    }
}