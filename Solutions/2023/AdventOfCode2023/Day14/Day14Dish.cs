namespace AdventOfCode2023.Day14;

using Coord = (int X, int Y);

public class Day14Dish
{
    /*
    O....#....
    O.OO#....#
    .....##...
    OO.#O....O
    .O.....O#.
    O.#..O.#.#
    ..O..#O..O
    .......O..
    #....###..
    #OO..#....
    */
    public Day14Dish(string input)
    {
        var lines = input.Split(Environment.NewLine);

        lengthY = lines.Length;
        lengthX = lines[0].Length;
        for (var y = lengthY - 1; y >= 0; y--)
        {
            var line = lines[^(y + 1)];
            for (var x = 0; x < lengthX; x++)
            {
                map[(x, y)] = line[x];
            }
        }
    }

    private readonly Dictionary<Coord, char> map = new();

    private readonly int lengthX;

    private readonly int lengthY;

    public int NorthLoad => map
            .Where(x => x.Value == 'O')
            .Select(x => x.Key.Y + 1)
            .Sum();

    public void TiltNorth()
    {
        var max = Enumerable
            .Repeat(lengthY, lengthX)
            .ToArray();

        for (var y = lengthY - 1; y >= 0; y--)
        {
            for (var x = 0; x < lengthX; x++)
            {
                var character = map[(x, y)];
                if (character == 'O')
                {
                    if (max[x] > y + 1)
                    {
                        max[x]--;
                        map[(x, max[x])] = 'O';
                        map[(x, y)] = '.';
                    }
                    else
                    {
                        max[x] = y;
                    }
                }
                else if (character == '#')
                {
                    max[x] = y;
                }
            }
        }
    }

    public void TiltEast()
    {
        var max = Enumerable
            .Repeat(lengthX, lengthY)
            .ToArray();

        for (var x = lengthX - 1; x >= 0; x--)
        {
            for (var y = 0; y < lengthY; y++)
            {
                var character = map[(x, y)];
                if (character == 'O')
                {
                    if (max[y] > x + 1)
                    {
                        max[y]--;
                        map[(max[y], y)] = 'O';
                        map[(x, y)] = '.';
                    }
                    else
                    {
                        max[y] = x;
                    }
                }
                else if (character == '#')
                {
                    max[y] = x;
                }
            }
        }
    }

    public void TiltSouth()
    {
        var min = Enumerable
            .Repeat(-1, lengthX)
            .ToArray();

        for (var y = 0; y < lengthY; y++)
        {
            for (var x = 0; x < lengthX; x++)
            {
                var character = map[(x, y)];
                if (character == 'O')
                {
                    if (min[x] < y - 1)
                    {
                        min[x]++;
                        map[(x, min[x])] = 'O';
                        map[(x, y)] = '.';
                    }
                    else
                    {
                        min[x] = y;
                    }
                }
                else if (character == '#')
                {
                    min[x] = y;
                }
            }
        }
    }

    public void TiltWest()
    {
        var max = Enumerable
            .Repeat(-1, lengthY)
            .ToArray();

        for (var x = 0; x < lengthX; x++)
        {
            for (var y = 0; y < lengthY; y++)
            {
                var character = map[(x, y)];
                if (character == 'O')
                {
                    if (max[y] < x - 1)
                    {
                        max[y]++;
                        map[(max[y], y)] = 'O';
                        map[(x, y)] = '.';
                    }
                    else
                    {
                        max[y] = x;
                    }
                }
                else if (character == '#')
                {
                    max[y] = x;
                }
            }
        }
    }

    public override string ToString()
        => string.Join(string.Empty, map
            .Where(x => x.Value == 'O')
            .Select(x => x.Key)
            .OrderBy(x => x.X)
            .ThenBy(x => x.Y));
}