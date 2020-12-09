using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day09
{
    public class Day09Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day09.Input.txt";
            var input = await this.GetInput(resource);

            return new Day09Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day09.Input.txt";
            var input = await this.GetInput(resource);

            return new Day09Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<long>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse);
        }
    }
}