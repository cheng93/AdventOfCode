using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day10
{
    public class Day10Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day10.Input.txt";
            var input = await this.GetInput(resource);

            return new Day10Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day10.Input.txt";
            var input = await this.GetInput(resource);

            return new Day10Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<int>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);
        }
    }
}