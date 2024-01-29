using System.Text;

namespace AdventOfCode2015.Day10;

public static class Day10Solver
{
    public static int PuzzleOne(string input, int iterations = 40) => Solve(input, iterations);

    public static int PuzzleTwo(string input) => Solve(input, 50);

    private static int Solve(string input, int iterations)
    {
        return Enumerable
            .Range(0, iterations)
            .Aggregate(input, (agg, _) => LookAndSay(agg))
            .Length;

        string LookAndSay(string str)
        {
            var builder = new StringBuilder();
            var current = str[0];
            var count = 1;

            for (var i = 1; i < str.Length; i++)
            {
                var character = str[i];

                if (character == current)
                {
                    count++;
                }
                else
                {
                    builder.Append($"{count}{current}");
                    current = character;
                    count = 1;
                }
            }

            builder.Append($"{count}{current}");

            return builder.ToString();
        }
    }
}