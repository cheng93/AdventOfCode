using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day07
{
    public class Day07Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day07MachineSolver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day07MachineSolver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<int>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day07.PuzzleOne.txt"))
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}