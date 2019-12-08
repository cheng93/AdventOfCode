using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day08
{
    public class Day08Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day08Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day08Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<int>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day08.PuzzleOne.txt"))
                .Select(x => x.ToString())
                .Select(int.Parse);
        }
    }
}