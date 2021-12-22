using System.Text;

namespace AdventOfCode2021.Day20;

public class Day20Algorithm
{
    // example: ..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..###..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###.######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#..#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#......#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.....####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#.......##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#
    public Day20Algorithm(string input)
    {
        _map = input.ToArray();
    }

    private char[] _map;

    public Day20Image Enhance(Day20Image image)
    {
        var copied = new HashSet<(int X, int Y)>(image.LightPixels);
        var minX = copied.Min(x => x.X);
        var minY = copied.Min(x => x.Y);
        var maxX = copied.Max(x => x.X);
        var maxY = copied.Max(x => x.Y);

        if (image.Background == '#')
        {
            for (var y = minY - 2; y <= maxY + 2; y++)
            {
                for (var x = minX - 2; x <= maxX + 2; x++)
                {
                    if (x < minX || x > maxX || y < minY || y > maxY)
                    {
                        copied.Add((x, y));
                    }
                }
            }
        }

        var set = new HashSet<(int X, int Y)>();

        for (var y = minY - 1; y <= maxY + 1; y++)
        {
            for (var x = minX - 1; x <= maxX + 1; x++)
            {
                var sb = new StringBuilder();
                for (var j = -1; j <= 1; j++)
                {
                    for (var i = -1; i <= 1; i++)
                    {
                        var isLight = copied.Contains((x + i, y + j));
                        sb.Append(isLight ? 1 : 0);
                    }
                }

                var binary = sb.ToString();
                var index = Convert.ToInt32(binary, 2);
                if (_map[index] == '#')
                {
                    set.Add((x, y));
                }
            }
        }

        var background = image.Background == '.'
            ? _map[0]
            : _map[511];

        return new Day20Image(set, background);
    }
}