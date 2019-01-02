namespace AdventOfCode2018.Day06
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day06Puzzle : Puzzle
    {
        public async override Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2018.Day06.PuzzleOne.txt";
            var input = await this.GetInput(resource);

            return new Day06Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2018.Day06.PuzzleOne.txt";
            var input = await this.GetInput(resource);

            return new Day06Solver().PuzzleTwo(input, 10000).ToString();
        }

        private async Task<IEnumerable<Point>> GetInput(string resource)
        {
            return (await this.ReadResource(resource))
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x =>
                {
                    var split = x
                        .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    return new Point(split[0], split[1]);
                });
        }
    }
}