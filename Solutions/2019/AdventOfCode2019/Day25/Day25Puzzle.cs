using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day25
{
    public class Day25Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day25Solver().PuzzleOne(input).ToString();
            // return new Day25ManualSolver().PuzzleOne(input).ToString();
        }

        public override Task<string> PuzzleTwo()
        {
            return Task.FromResult("Year 2019 Completed");
        }

        private async Task<IEnumerable<long>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day25.PuzzleOne.txt"))
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse);
        }
    }
}