using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day14
{
    public class Day14Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day14.Input.txt";
            var input = await this.GetInput(resource);

            return new Day14Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day14.Input.txt";
            var input = await this.GetInput(resource);

            return new Day14Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<string>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}