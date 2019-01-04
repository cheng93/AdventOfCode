namespace AdventOfCode2017.Day17
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day17Puzzle : Puzzle
    {
        public override Task<string> PuzzleOne()
        {
            var result = new Day17Solver().PuzzleOne(328).ToString();

            return Task.FromResult(result);
        }

        public override Task<string> PuzzleTwo()
        {
            var result = new Day17Solver().PuzzleTwo(328).ToString();

            return Task.FromResult(result);
        }
    }
}