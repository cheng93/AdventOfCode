namespace AdventOfCode2017.Day03
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day03Puzzle : Puzzle
    {
        public override Task<string> PuzzleOne()
        {
            var result = new Day03Solver().PuzzleOne(265149).ToString();

            return Task.FromResult(result);
        }

        public override Task<string> PuzzleTwo()
        {
            var result = new Day03Solver().PuzzleTwo(265149).ToString();

            return Task.FromResult(result);
        }
    }
}