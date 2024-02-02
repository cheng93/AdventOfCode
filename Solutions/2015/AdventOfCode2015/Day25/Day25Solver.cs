namespace AdventOfCode2015.Day25;

public static class Day25Solver
{
    public static long PuzzleOne(string input)
    {
        var splits = input
            .Replace(",", string.Empty)
            .Replace(".", string.Empty)
            .Split(' ')
            .Where(x => int.TryParse(x, out _))
            .Select(int.Parse)
            .ToArray();

        var row = splits[0];
        var column = splits[1];

        var target = row * (row - 1) / 2 + 1;
        for (var i = 2; i <= column; i++)
        {
            target += row + i - 1;
        }

        var current = 20151125L;

        for (var i = 1; i < target; i++)
        {
            current = current * 252533 % 33554393;
        }

        return current;
    }
}