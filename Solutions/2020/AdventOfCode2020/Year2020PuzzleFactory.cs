using System;
using AdventOfCode.Abstractions;
using AdventOfCode2020.Day01;

namespace AdventOfCode2020
{
    public class Year2020PuzzleFactory : IPuzzleFactory
    {
        public IPuzzle Create(int day)
            => day switch
            {
                1 => new Day01Puzzle(),
                _ => throw new ArgumentException(nameof(day))
            };
    }
}
