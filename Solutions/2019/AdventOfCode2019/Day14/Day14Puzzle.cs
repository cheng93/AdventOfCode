using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day14
{
    public class Day14Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day14Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day14Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<string>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day14.PuzzleOne.txt"))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}