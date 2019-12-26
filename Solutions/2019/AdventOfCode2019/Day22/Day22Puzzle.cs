using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day22
{
    public class Day22Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day22Solver().PuzzleOne(input)
                .Select((x, i) => new
                {
                    Value = x,
                    Index = i
                }
                )
                .First(x => x.Value == 2019)
                .Index
                .ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day22Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<string>> GetInput()
        {
            return (await this.ReadResource("AdventOfCode2019.Day22.PuzzleOne.txt"))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}