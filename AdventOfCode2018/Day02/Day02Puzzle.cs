
namespace AdventOfCode2018.Day02
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Day02Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day02.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new Day02Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day02.PuzzleOne.txt";

            var input = await this.GetInput(resource);

            return new Day02Solver().PuzzleTwo(input);
        }

        private async Task<IEnumerable<string>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}