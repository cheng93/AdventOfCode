using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day09
{
    public class Day09Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return string.Join(',', new Day09Solver().PuzzleOne(input));
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day09Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<long>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day09.PuzzleOne.txt"))
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse);
        }
    }
}