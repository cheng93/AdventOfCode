namespace AdventOfCode2024.Day02;

public class Day02Report
{
    // 7 6 4 2 1
    public Day02Report(string input)
    {
        Levels = input
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
    }

    public int[] Levels { get; }
}