namespace AdventOfCode2018.Day09
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day09Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day09.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day09Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day09.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day09Solver().PuzzleTwo(input).ToString();
        }
    }
}