namespace AdventOfCode2018.Day07
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day07Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day07.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new Day07Solver().PuzzleOne(input);
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day07.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new Day07Solver().PuzzleTwo(input, 5, 60).ToString();
        }

        private async Task<IEnumerable<string>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}