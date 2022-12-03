using AdventOfCode2022.Day01;
using AdventOfCode2022.Day02;
using AdventOfCode2022.Day03;

namespace AdventOfCode2022;

public class Year2022PuzzleFactory : IPuzzleFactory
{
    public IPuzzle Create(int day)
        => day switch
        {
            1 => new Day01Puzzle(),
            2 => new Day02Puzzle(),
            3 => new Day03Puzzle(),
            _ => throw new ArgumentException(nameof(day))
        };
}
