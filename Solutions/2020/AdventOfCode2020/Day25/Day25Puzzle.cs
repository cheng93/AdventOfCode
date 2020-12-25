using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day25
{
    public class Day25Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day25.Input.txt";
            var input = await this.GetInput(resource);

            return new Day25Solver().PuzzleOne(input).ToString();
        }

        public override Task<string> PuzzleTwo()
        {
            return Task.FromResult("Year 2020 Completed");
        }

        private async Task<IEnumerable<int>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}