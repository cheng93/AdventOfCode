namespace AdventOfCode2017.Day10
{
    using System.Linq;
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day10Puzzle : Puzzle
    {
        public override Task<string> PuzzleOne()
        {
            var input = "70,66,255,2,48,0,54,48,80,141,244,254,160,108,1,41";

            var result = new Day10Solver().PuzzleOne(input, Enumerable.Range(0, 256)).ToString();

            return Task.FromResult(result);
        }

        public override Task<string> PuzzleTwo()
        {
            var input = "70,66,255,2,48,0,54,48,80,141,244,254,160,108,1,41";

            var result = new Day10Solver().PuzzleTwo(input);

            return Task.FromResult(result);
        }
    }
}