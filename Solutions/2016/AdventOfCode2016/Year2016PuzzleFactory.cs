namespace AdventOfCode2016
{
    using System.Collections.Generic;
    using AdventOfCode.Abstractions;
    using AdventOfCode2016.Day01;
    using AdventOfCode2016.Day02;
    using AdventOfCode2016.Day03;
    using AdventOfCode2016.Day04;
    using AdventOfCode2016.Day05;
    using AdventOfCode2016.Day06;
    using AdventOfCode2016.Day07;
    using AdventOfCode2016.Day08;
    using AdventOfCode2016.Day09;
    using AdventOfCode2016.Day10;
    using AdventOfCode2016.Day11;
    using AdventOfCode2016.Day12;
    using AdventOfCode2016.Day13;
    using AdventOfCode2016.Day14;
    using AdventOfCode2016.Day15;

    public class Year2016PuzzleFactory : IPuzzleFactory
    {
        private static IDictionary<int, IPuzzle> puzzles = new Dictionary<int, IPuzzle>()
        {
            {1, new Day01Puzzle()},
            {2, new Day02Puzzle()},
            {3, new Day03Puzzle()},
            {4, new Day04Puzzle()},
            {5, new Day05Puzzle()},
            {6, new Day06Puzzle()},
            {7, new Day07Puzzle()},
            {8, new Day08Puzzle()},
            {9, new Day09Puzzle()},
            {10, new Day10Puzzle()},
            {11, new Day11Puzzle()},
            {12, new Day12Puzzle()},
            {13, new Day13Puzzle()},
            {14, new Day14Puzzle()},
            {15, new Day15Puzzle()},
            // {16, new Day16Puzzle()},
            // {17, new Day17Puzzle()},
            // {18, new Day18Puzzle()},
            // {19, new Day19Puzzle()},
            // {20, new Day20Puzzle()},
            // {21, new Day21Puzzle()},
            // {22, new Day22Puzzle()},
            // {23, new Day23Puzzle()},
            // {24, new Day24Puzzle()},
            // {25, new Day25Puzzle()}
        };

        public IPuzzle Create(int day) => puzzles[day];
    }
}
