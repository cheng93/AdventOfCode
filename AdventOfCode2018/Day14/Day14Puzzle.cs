namespace AdventOfCode2018.Day14
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day14Puzzle : Puzzle
    {
        public override Task<string> PuzzleOne()
        {
            var input = 760221;
            var result = new Day14Solver().PuzzleOne(input);
            return Task.FromResult(result);
        }

        public override Task<string> PuzzleTwo()
        {
            var input = "760221";
            var result = new Day14Solver().PuzzleTwo(input);
            return Task.FromResult(result.ToString());
        }
    }
}