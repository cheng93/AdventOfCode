using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day19
{
    public class Day19Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day19Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day19Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<long>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day19.PuzzleOne.txt"))
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse);
        }
    }
}