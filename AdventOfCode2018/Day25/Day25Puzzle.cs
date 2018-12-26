namespace AdventOfCode2018.Day25
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Day25Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day25.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new Day25Solver().PuzzleOne(input).ToString();
        }

        public override Task<string> PuzzleTwo()
        {
            throw new System.NotImplementedException();
        }

        private async Task<IEnumerable<string>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}