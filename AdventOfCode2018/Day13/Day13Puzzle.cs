namespace AdventOfCode2018.Day13
{
    using System.Threading.Tasks;

    public class Day13Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day13.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day13Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day13.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day13Solver().PuzzleTwo(input).ToString();
        }
    }
}