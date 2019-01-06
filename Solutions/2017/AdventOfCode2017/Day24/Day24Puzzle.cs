namespace AdventOfCode2017.Day24
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day24Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day24.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day24Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day24.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day24Solver().PuzzleTwo(input).ToString();
        }
    }
}