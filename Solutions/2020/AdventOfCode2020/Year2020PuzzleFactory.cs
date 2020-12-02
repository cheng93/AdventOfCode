﻿using System;
using AdventOfCode.Abstractions;
using AdventOfCode2020.Day01;
using AdventOfCode2020.Day02;

namespace AdventOfCode2020
{
    public class Year2020PuzzleFactory : IPuzzleFactory
    {
        public IPuzzle Create(int day)
            => day switch
            {
                1 => new Day01Puzzle(),
                2 => new Day02Puzzle(),
                _ => throw new ArgumentException(nameof(day))
            };
    }
}
