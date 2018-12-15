namespace AdventOfCode2018.Day15
{
    using System.Threading.Tasks;

    public class Day15Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day15.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day15Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day15.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day15Solver().PuzzleTwo(input).ToString();
        }
    }
}