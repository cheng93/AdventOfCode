namespace AdventOfCode2018.Day19
{
    using System.Threading.Tasks;

    public class Day19Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day19.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day19Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day19.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day19Solver().PuzzleTwo(input).ToString();
        }
    }
}