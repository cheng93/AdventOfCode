namespace AdventOfCode2017.Day19
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day19Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2017.Day19.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day19Solver().PuzzleOne(input);
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2017.Day19.Input.txt";

            var input = await this.ReadResource(resource);

            return new Day19Solver().PuzzleTwo(input).ToString();
        }
    }
}