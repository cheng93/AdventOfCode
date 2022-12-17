namespace AdventOfCode2022.Day17;

public static class Day17RockFactory
{
    public static IEnumerable<(int X, int Y)> Horizontal(int height)
    {
        return Enumerable.Range(2, 4).Select(x => (x, height + 4));
    }

    public static IEnumerable<(int X, int Y)> Plus(int height)
    {
        var y = height + 4;
        for (var i = 0; i < 3; i++)
        {
            yield return (3, y + i);
            if (i == 1)
            {

                yield return (2, y + i);
                yield return (4, y + i);
            }
        }
    }

    public static IEnumerable<(int X, int Y)> L(int height)
    {
        var y = height + 4;
        for (var i = 0; i < 3; i++)
        {
            var x = 2 + i;
            yield return (x, y);
            if (i == 2)
            {
                yield return (x, y + 1);
                yield return (x, y + 2);
            }
        }
    }

    public static IEnumerable<(int X, int Y)> Vertical(int height)
    {
        return Enumerable.Range(height + 4, 4).Select(y => (2, y));
    }

    public static IEnumerable<(int X, int Y)> Square(int height)
    {
        var y = height + 4;
        for (var i = 0; i < 2; i++)
        {
            var x = 2 + i;

            yield return (x, y);
            yield return (x, y + 1);
        }
    }
}