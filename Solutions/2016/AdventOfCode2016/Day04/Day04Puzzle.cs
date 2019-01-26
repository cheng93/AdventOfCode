namespace AdventOfCode2016.Day04
{
    using System;
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;

    public class Day04Puzzle : Puzzle
    {
        private const string resource = "AdventOfCode2016.Day04.Input.txt";

        public async override Task<string> PuzzleOne()
        {
            var input = await this.ReadResource(resource);

            return new Day04Solver().PuzzleOne(input).ToString();
        }

        public async override Task<string> PuzzleTwo()
        {
            var input = await this.ReadResource(resource);

            var result = new Day04Solver().PuzzleTwo(input);

            var output = string.Join(Environment.NewLine, result);

            return output;
        }
    }
}