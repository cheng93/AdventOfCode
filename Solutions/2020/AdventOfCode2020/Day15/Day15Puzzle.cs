using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCode.Abstractions;

namespace AdventOfCode2020.Day15
{
    public class Day15Puzzle : Puzzle
    {
        private const string Input = "0,14,6,20,1,4";

        public override Task<string> PuzzleOne()
        {
            var input = this.GetInput();

            return Task.FromResult(new Day15Solver().PuzzleOne(input).ToString());
        }

        public override Task<string> PuzzleTwo()
        {
            var input = this.GetInput();

            return Task.FromResult(new Day15Solver().PuzzleTwo(input).ToString());
        }

        private IEnumerable<int> GetInput()
        {
            return Input
                .Split(',')
                .Select(int.Parse);
        }
    }
}