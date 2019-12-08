using System;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day02
{
    public class Day02Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2019.Day02.PuzzleOne.txt";
            var input = (await this.ReadResource(resource))
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            input[1] = 12;
            input[2] = 2;
            return new Day02MachineSolver().PuzzleOne(input);
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2019.Day02.PuzzleOne.txt";
            var input = (await this.ReadResource(resource))
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            input[1] = 64;
            input[2] = 29;
            return new Day02MachineSolver().PuzzleOne(input);
        }
    }
}