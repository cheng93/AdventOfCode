namespace AdventOfCode2018.Day11
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day11Puzzle : Puzzle
    {
        public override Task<string> PuzzleOne()
        {
            var input = 2866;
            var result = new Day11Solver().PuzzleOne(input);
            return Task.FromResult($"{result.X},{result.Y}");
        }

        public override Task<string> PuzzleTwo()
        {
            var input = 2866;
            var result = new Day11Solver().PuzzleTwo(input);
            return Task.FromResult($"{result.Point.X},{result.Point.Y},{result.Size}");
        }
    }
}