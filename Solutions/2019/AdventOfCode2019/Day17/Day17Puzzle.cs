using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day17
{
    public class Day17Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day17Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = (await this.GetInput()).ToArray();
            input[0] = 2;
            return new Day17Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<long>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day17.PuzzleOne.txt"))
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse);
        }
    }
}