using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2019.Day10
{
    public class Day10Puzzle : Puzzle
    {
        public override async Task<string> PuzzleOne()
        {
            var input = await this.GetInput();
            return new Day10Solver().PuzzleOne(input).ToString();
        }

        public override async Task<string> PuzzleTwo()
        {
            var input = await this.GetInput();
            return new Day10Solver().PuzzleTwo(input, new Point(25, 31), 200).ToString();
        }

        private async Task<string> GetInput()
        {
            return await this.ReadResource("AdventOfCode2019.Day10.PuzzleOne.txt");
        }
    }
}