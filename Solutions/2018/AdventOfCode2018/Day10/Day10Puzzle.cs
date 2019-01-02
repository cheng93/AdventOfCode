
namespace AdventOfCode2018.Day10
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day10Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day10.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            var iterations = new Day10Solver().PuzzleOne(input, out var points);

            return new Day10Output().Draw(points);
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day10.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new Day10Solver().PuzzleOne(input, out var points).ToString();
        }

        private async Task<IEnumerable<string>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}