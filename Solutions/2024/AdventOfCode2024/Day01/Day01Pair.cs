namespace AdventOfCode2024.Day01;

public class Day01Pair
{
    // 3   4
    public Day01Pair(string input)
    {
        var splits = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        Left = splits[0];
        Right = splits[1];

    }

    public int Left { get; }

    public int Right { get; }
}