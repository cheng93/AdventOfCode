using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day24
{
    public class Day24Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day24.Input.txt";
            var input = await this.GetInput(resource);

            return new Day24AlternateSolver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day24.Input.txt";
            var input = await this.GetInput(resource);

            return new Day24AlternateSolver().PuzzleTwo(input).ToString();
        }

        private async Task<IEnumerable<string>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}