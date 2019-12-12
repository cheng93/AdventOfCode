using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day12
{
    public class Day12Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day12Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day12Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<string>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day12.PuzzleOne.txt"))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}