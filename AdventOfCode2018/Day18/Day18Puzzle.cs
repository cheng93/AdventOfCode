namespace AdventOfCode2018.Day18
{
    using System.Threading.Tasks;

    public class Day18Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day18.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day18Solver().PuzzleOne(input, 50).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day18.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day18Solver().PuzzleTwo(input, 50).ToString();
        }
    }
}