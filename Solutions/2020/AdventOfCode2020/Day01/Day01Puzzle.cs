using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day01
{
    public class Day01Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day01.Input.txt";
            var input = await this.GetInput(resource);

            return new Day01Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day01.Input.txt";
            var input = await this.GetInput(resource);

            return new Day01Solver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<int>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x));
        }
    }
}