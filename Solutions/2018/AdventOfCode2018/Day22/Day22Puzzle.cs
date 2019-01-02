namespace AdventOfCode2018.Day22
{
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day22Puzzle : Puzzle
    {
        public override Task<string> PuzzleOne()
        {
            var result = new Day22Solver().PuzzleOne(11739, "11,718").ToString();
            return Task.FromResult(result);
        }

        public override Task<string> PuzzleTwo()
        {
            var result = new Day22Solver().PuzzleTwo(11739, "11,718").ToString();
            return Task.FromResult(result);
        }
    }
}