using AdventOfCode2022.Day01;

namespace AdventOfCode2022;

public class Year2022PuzzleFactory : IPuzzleFactory
{
    public IPuzzle Create(int day)
        => day switch
        {
            1 => new Day01Puzzle(),
            _ => throw new ArgumentException(nameof(day))
        };
}
