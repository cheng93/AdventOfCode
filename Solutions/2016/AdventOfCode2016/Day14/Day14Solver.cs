using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2016.Day14;

public static class Day14Solver
{
    public static int PuzzleOne(string input) => Solve(input, false);

    public static int PuzzleTwo(string input) => Solve(input, true);

    private static int Solve(string input, bool keyStretching)
    {
        var keyIndex = new List<int>();
        var search = new Dictionary<int, string>();
        var index = 0;

        using var md5 = MD5.Create();

        while (keyIndex.Count < 64)
        {
            var str = $"{input}{index}";
            var iterations = keyStretching ? 2017 : 1;
            for (var i = 0; i < iterations; i++)
            {
                str = Hash(str);
            }

            var found = new List<int>();
            foreach (var kvp in search)
            {
                if (str.Contains(kvp.Value))
                {
                    keyIndex.Add(kvp.Key);
                    found.Add(kvp.Key);
                }
            }

            for (var i = 0; i < str.Length - 2; i++)
            {
                var c = str[i];
                var triplet = str[i..(i + 3)];
                if (triplet == c.ToString().PadLeft(3, c))
                {
                    search[index] = c.ToString().PadLeft(5, c);
                    break;
                }
            }

            foreach (var i in found)
            {
                search.Remove(i);
            }
            search.Remove(index - 1000);
            index++;
        }

        string Hash(string s)
        {
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(s));
            return Convert.ToHexString(hash).ToLower();
        }

        return keyIndex
            .OrderBy(x => x)
            .Take(64)
            .Last();
    }
}