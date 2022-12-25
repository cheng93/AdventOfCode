using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode2016.Day17;

public static class Day17Solver
{
    public static string PuzzleOne(string input) => Solve(input).First();

    public static int PuzzleTwo(string input) => Solve(input).Last().Length;

    private static IEnumerable<string> Solve(string input)
    {
        var rooms = new HashSet<(int X, int Y)>(
            Enumerable
                .Range(0, 4)
                .SelectMany(x => Enumerable
                    .Range(0, 4)
                    .Select(y => (X: x, Y: y)))
        );
        var directions = new (int X, int Y)[]
        {
            (0, -1),
            (0, 1),
            (-1, 0),
            (1, 0),
        };
        var letters = new[] { 'U', 'D', 'L', 'R' };
        using var md5 = MD5.Create();

        var queue = new Queue<((int X, int Y) Point, string Path)>();
        queue.Enqueue(((0, 0), string.Empty));

        while (queue.Any())
        {
            var (point, path) = queue.Dequeue();
            if (point == (3, 3))
            {
                yield return path;
                continue;
            }

            var hash = Hash(input + path);

            for (var i = 0; i < directions.Length; i++)
            {
                var direction = directions[i];
                var neighbour = (point.X + direction.X, point.Y + direction.Y);
                if (!rooms.Contains(neighbour) || !IsOpen())
                {
                    continue;
                }

                queue.Enqueue((neighbour, path + letters[i]));

                bool IsOpen() => !int.TryParse(hash[i].ToString(), out var _) && hash[i] != 'a';
            }
        }

        string Hash(string s)
        {
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(s));
            return Convert.ToHexString(hash).ToLower();
        }
    }
}