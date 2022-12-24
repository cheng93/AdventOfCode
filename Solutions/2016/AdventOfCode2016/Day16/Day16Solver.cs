using System.Text;

namespace AdventOfCode2016.Day16;

public static class Day16Solver
{
    public static string PuzzleOne(string input, int length = 272) => Solve(input, length);

    public static string PuzzleTwo(string input) => Solve(input, 35651584);

    private static string Solve(string input, int length)
    {
        while (input.Length < length)
        {
            input = DragonCurve(input);
        }

        var checksum = input[..length];
        while (checksum.Length % 2 == 0)
        {
            checksum = Checksum(checksum);
        }

        return checksum;

        string DragonCurve(string str)
        {
            var sb = new StringBuilder(str);
            sb.Append('0');
            for (var i = str.Length - 1; i >= 0; i--)
            {
                var c = str[i] == '1' ? '0' : '1';
                sb.Append(c);
            }

            return sb.ToString();
        }

        string Checksum(string str)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length - 1; i = i + 2)
            {
                var pair = str[i..(i + 2)];
                var c = pair[0] == pair[1] ? '1' : '0';
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}