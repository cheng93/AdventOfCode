using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day11
{
    public class Day11Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day11.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day11Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day11.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day11Solver().PuzzleTwo(input).ToString();
        }
    }
}