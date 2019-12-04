using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day04
{
    public class Day04Puzzle : IPuzzle
    {
        private const string Input = "248345-746315";
        public Task<string> PuzzleOne()
        {
            var inputs = Input
                .Split('-')
                .Select(int.Parse)
                .ToArray();

            var result = new Day04Solver().PuzzleOne(inputs[0], inputs[1]).ToString();
            return Task.FromResult(result);
        }

        public Task<string> PuzzleTwo()
        {
            var inputs = Input
                .Split('-')
                .Select(int.Parse)
                .ToArray();

            var result = new Day04Solver().PuzzleTwo(inputs[0], inputs[1]).ToString();
            return Task.FromResult(result);
        }
    }
}