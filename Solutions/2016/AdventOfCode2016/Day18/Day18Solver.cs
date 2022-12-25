namespace AdventOfCode2016.Day18;

public static class Day18Solver
{
    public static int PuzzleOne(string input, int rows = 40) => Solve(input).Take(rows).Sum();

    public static int PuzzleTwo(string input) => Solve(input).Take(400000).Sum();

    private static IEnumerable<int> Solve(string input)
    {
        var tiles = new List<string>();
        tiles.Add(input);
        yield return input.Count(x => x == '.');

        var i = 1;
        while (true)
        {
            var prev = tiles[i - 1];
            var tile = string.Empty;
            for (var j = 0; j < input.Length; j++)
            {
                var check = string.Empty;
                if (j == 0)
                {
                    check = prev[0..2].PadLeft(3, '.');
                }
                else if (j == input.Length - 1)
                {
                    check = prev[^2..].PadRight(3, '.');
                }
                else
                {
                    check = prev[(j - 1)..(j + 2)];
                }

                tile += IsTrap() ? '^' : '.';

                bool IsTrap()
                    => check[0] != check[1] && check[0] != check[2]
                        || check[2] != check[0] && check[2] != check[1];
            }

            yield return tile.Count(x => x == '.');
            tiles.Add(tile);
            i++;
        }
    }
}