namespace AdventOfCode2017.Day07
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day07Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day07.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day07Solver().PuzzleOne(input);
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day07.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day07Solver().PuzzleTwo(input).ToString();
        }
    }
}