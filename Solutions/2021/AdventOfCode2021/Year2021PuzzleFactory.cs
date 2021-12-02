using AdventOfCode2021.Day01;
using AdventOfCode2021.Day02;

namespace AdventOfCode2021;

public class Year2021PuzzleFactory : IPuzzleFactory
{
    public IPuzzle Create(int day)
        => day switch
        {
            1 => new Day01Puzzle(),
            2 => new Day02Puzzle(),
            _ => throw new ArgumentException(nameof(day))
        };
}
