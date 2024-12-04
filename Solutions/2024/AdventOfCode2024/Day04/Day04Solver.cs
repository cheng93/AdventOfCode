namespace AdventOfCode2024.Day04;

public static class Day04Solver
{
    public static int PuzzleOne(string input)
    {
        var splits = input
            .Split(Environment.NewLine)
            .ToArray();
        var grid = new Dictionary<Day04Point, char>();
        var xPoints = new HashSet<Day04Point>();
        for (var i = 0; i < splits.Length; i++)
        {
            for (var j = 0; j < splits[i].Length; j++)
            {
                var letter = splits[i][j];
                grid.Add(new(i, j), letter);
                if (letter == 'X')
                {
                    xPoints.Add(new(i, j));
                }
            }
        }

        return xPoints
            .SelectMany(x =>
                new IEnumerable<Day04Point>[]
                {
                    Path(x, p => p.Down()),
                    Path(x, p => p.Down().Left()),
                    Path(x, p => p.Down().Right()),
                    Path(x, p => p.Left()),
                    Path(x, p => p.Right()),
                    Path(x, p => p.Up()),
                    Path(x, p => p.Up().Left()),
                    Path(x, p => p.Up().Right())
                }
                .Select(path => string.Join("", path.TakeWhile(grid.ContainsKey).Select(point => grid[point]))))
            .Count(IsXmas);

        IEnumerable<Day04Point> Path(Day04Point origin, Func<Day04Point, Day04Point> next)
        {
            var current = origin;
            for (var i = 0; i < 4; i++)
            {
                yield return current;
                current = next(current);
            }
        }

        bool IsXmas(string value) => value is "XMAS";
    }

    public static int PuzzleTwo(string input)
    {
        var splits = input
            .Split(Environment.NewLine)
            .ToArray();
        var grid = new Dictionary<Day04Point, char>();
        var aPoints = new HashSet<Day04Point>();
        for (var i = 0; i < splits.Length; i++)
        {
            for (var j = 0; j < splits[i].Length; j++)
            {
                var letter = splits[i][j];
                grid.Add(new(i, j), letter);
                if (letter == 'A')
                {
                    aPoints.Add(new(i, j));
                }
            }
        }

        return aPoints
            .Select(x => string.Join("", Path(x).Where(grid.ContainsKey).Select(point => grid[point])))
            .Count(IsXMas);

        IEnumerable<Day04Point> Path(Day04Point origin)
        {
            yield return origin.Down().Left();
            yield return origin.Down().Right();
            yield return origin.Up().Left();
            yield return origin.Up().Right();
        }

        bool IsXMas(string value) => string.Join("", value.OrderBy(x => x)) == "MMSS"
            && value[0] != value[3];
    }
}