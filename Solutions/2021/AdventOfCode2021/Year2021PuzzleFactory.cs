using AdventOfCode2021.Day01;
using AdventOfCode2021.Day02;
using AdventOfCode2021.Day03;
using AdventOfCode2021.Day04;
using AdventOfCode2021.Day05;

namespace AdventOfCode2021;

public class Year2021PuzzleFactory : IPuzzleFactory
{
    public IPuzzle Create(int day)
        => day switch
        {
            1 => new Day01Puzzle(),
            2 => new Day02Puzzle(),
            3 => new Day03Puzzle(),
            4 => new Day04Puzzle(),
            5 => new Day05Puzzle(),
            _ => throw new ArgumentException(nameof(day))
        };
}
