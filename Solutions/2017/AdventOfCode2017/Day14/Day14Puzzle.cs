namespace AdventOfCode2017.Day14
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day14Puzzle : Puzzle
    {
        public override Task<string> PuzzleOne()
        {
            var result = new Day14Solver().PuzzleOne("hxtvlmkl").ToString();

            return Task.FromResult(result);
        }

        public override Task<string> PuzzleTwo()
        {
            var result = new Day14Solver().PuzzleTwo("hxtvlmkl").ToString();

            return Task.FromResult(result);
        }
    }
}