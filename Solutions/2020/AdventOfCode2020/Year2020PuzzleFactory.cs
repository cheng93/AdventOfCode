using System;
using AdventOfCode.Abstractions;
using AdventOfCode2020.Day01;
using AdventOfCode2020.Day02;
using AdventOfCode2020.Day03;
using AdventOfCode2020.Day04;
using AdventOfCode2020.Day05;
using AdventOfCode2020.Day06;
using AdventOfCode2020.Day07;
using AdventOfCode2020.Day08;
using AdventOfCode2020.Day09;

namespace AdventOfCode2020
{
    public class Year2020PuzzleFactory : IPuzzleFactory
    {
        public IPuzzle Create(int day)
            => day switch
            {
                1 => new Day01Puzzle(),
                2 => new Day02Puzzle(),
                3 => new Day03Puzzle(),
                4 => new Day04Puzzle(),
                5 => new Day05Puzzle(),
                6 => new Day06Puzzle(),
                7 => new Day07Puzzle(),
                8 => new Day08Puzzle(),
                9 => new Day09Puzzle(),
                _ => throw new ArgumentException(nameof(day))
            };
    }
}
