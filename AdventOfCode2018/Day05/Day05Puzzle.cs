namespace AdventOfCode2018.Day05
{
    using System.Threading.Tasks;

    public class Day05Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day05.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day05Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day05.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day05Solver().PuzzleTwo(input).ToString();
        }
    }
}