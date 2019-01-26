namespace AdventOfCode2016.Day05
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day05Puzzle : Puzzle
    {
        private const string input = "ugkcyxxp";

        public override Task<string> PuzzleOne()
        {
            var result = new Day05Solver().PuzzleOne(input);

            return Task.FromResult(result);
        }

        public override Task<string> PuzzleTwo()
        {
            var result = new Day05Solver().PuzzleTwo(input);

            return Task.FromResult(result);
        }
    }
}