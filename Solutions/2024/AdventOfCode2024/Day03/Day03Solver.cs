using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day03;

public static class Day03Solver
{
    public static int PuzzleOne(string input)
    {
        var matches = Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)");
        return matches
            .Sum(x => x.Groups.Values
                    .Skip(1)
                    .Select(y => int.Parse(y.Value))
                    .Aggregate((y, z) => y * z));
    }

    public static int PuzzleTwo(string input)
    {
        var matches = Regex.Matches(input, @"do(?:n't)?\(\)|mul\((\d{1,3}),(\d{1,3})\)");
        var enabled = true;
        var sum = 0;
        foreach (Match match in matches)
        {
            if (match.Value == "do()")
            {
                enabled = true;
            }
            else if (match.Value == "don't()")
            {
                enabled = false;
            }
            else if (enabled)
            {
                sum += match.Groups.Values
                    .Skip(1)
                    .Select(y => int.Parse(y.Value))
                    .Aggregate((y, z) => y * z);
            }
        }
        return sum;
    }
}