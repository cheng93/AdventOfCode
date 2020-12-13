using System;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day13
{
    public class Day13Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day13.Input.txt";
            var input = await this.GetInput(resource);

            return new Day13Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day13.Input.txt";
            var input = await this.GetInput(resource);

            return new Day13Solver().PuzzleTwo(input).ToString();
        }

        private async Task<string> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)[1];
        }
    }
}