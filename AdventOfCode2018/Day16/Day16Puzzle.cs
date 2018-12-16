namespace AdventOfCode2018.Day16
{
    using System.Threading.Tasks;

    public class Day16Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day16.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            return new Day16Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day16.PuzzleOne.txt";

            var input = await this.ReadResource(resource);

            resource = "AdventOfCode2018.Day16.PuzzleTwo.txt";

            var testProgram = await this.ReadResource(resource);

            return new Day16Solver().PuzzleTwo(input, testProgram).ToString();
        }
    }
}