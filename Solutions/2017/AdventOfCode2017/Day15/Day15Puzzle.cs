namespace AdventOfCode2017.Day15
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day15Puzzle : Puzzle
    {
        public override Task<string> PuzzleOne()
        {
            var result = new Day15Solver().PuzzleOne(591, 393).ToString();

            return Task.FromResult(result);
        }

        public override Task<string> PuzzleTwo()
        {
            var result = new Day15Solver().PuzzleTwo(591, 393).ToString();

            return Task.FromResult(result);
        }
    }
}