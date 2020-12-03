using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day03
{
    public class Day03Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var resource = "AdventOfCode2020.Day03.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day03Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var resource = "AdventOfCode2020.Day03.Input.txt";
            var input = await this.ReadResource(resource);

            return new Day03Solver().PuzzleTwo(input).ToString();
        }
    }
}