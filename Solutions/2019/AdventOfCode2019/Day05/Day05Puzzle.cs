using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day05
{
    public class Day05Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return string.Join(',', new Day05Solver().PuzzleOne(input));
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return string.Join(',', new Day05Solver().PuzzleTwo(input));
        }

        private async Task<IEnumerable<int>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day05.PuzzleOne.txt"))
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x));
        }
    }
}