namespace AdventOfCode2022;

public class Year2022PuzzleFactory : IPuzzleFactory
{
    public IPuzzle Create(int day)
        => day switch
        {
            _ => throw new ArgumentException(nameof(day))
        };
}
