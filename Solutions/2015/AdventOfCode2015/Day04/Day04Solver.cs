namespace AdventOfCode2015.Day04;

public static class Day04Solver
{
    public static int PuzzleOne(string input) => Solve(input, 5);

    public static int PuzzleTwo(string input) => Solve(input, 6);

    private static int Solve(string input, int count)
        => Generate()
            .Select(x => new
            {
                Index = x,
                Hash = CreateMD5($"{input}{x}")
            })
            .First(x => x.Hash.StartsWith(string.Join("", Enumerable.Repeat("0", count))))
            .Index;

    private static string CreateMD5(string input)
    {
        using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
        var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);

        return Convert.ToHexString(hashBytes);
    }

    private static IEnumerable<int> Generate()
    {
        var i = 1;
        while (true)
        {
            yield return i;
            i++;
        }
    }
}