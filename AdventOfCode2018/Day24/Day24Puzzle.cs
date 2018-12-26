namespace AdventOfCode2018.Day24
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day24Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day24.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day24Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day24.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day24Solver().PuzzleTwo(input).ToString();
        }
    }
}