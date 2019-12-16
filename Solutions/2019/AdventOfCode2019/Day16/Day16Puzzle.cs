using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day16
{
    public class Day16Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return string.Join(string.Empty, new Day16Solver().PuzzleOne(input, 100).Take(8));
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day16Solver().PuzzleTwo(input);
        }

        private async Task<IEnumerable<int>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day16.PuzzleOne.txt"))
                .Select(x => int.Parse(x.ToString()));
        }
    }
}