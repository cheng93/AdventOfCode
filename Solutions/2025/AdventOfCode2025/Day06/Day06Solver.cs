namespace AdventOfCode2025.Day06;

public static class Day06Solver
{
    public static long PuzzleOne(string input, int numbers = 4)
    {
        var lines = input
            .Split(Environment.NewLine)
            .Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToArray();

        var sum = 0L;

        for (var i = 0; i < lines[0].Length; i++)
        {
            var acc = long.Parse(lines[0][i]);
            for (var j = 1; j < numbers; j++)
            {
                var num = int.Parse(lines[j][i]);
                if (lines[numbers][i] == "+")
                {
                    acc += num;
                }
                else
                {
                    acc *= num;
                }
            }

            sum += acc;
        }

        return sum;
    }

    public static long PuzzleTwo(string input, int numbers = 4)
    {
        var lines = input.Split(Environment.NewLine);

        var parts = lines
            .Take(numbers)
            .ToArray();

        var gaps = Enumerable
            .Range(0, lines[0].Length)
            .Where(x => parts.All(p => p[x] == ' '))
            .ToArray();
        gaps = [-1, ..gaps, lines[0].Length];

        var operators = lines
            .Last()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var sum = 0L;

        for (var i = 0; i < operators.Length; i++)
        {
            var gap = gaps[i];
            var acc = GetNumber(gap + 1);
            for (var j = gap + 2; j < gaps[i + 1]; j++)
            {
                var num = GetNumber(j);
                if (operators[i] == "+")
                {
                    acc += num;
                }
                else
                {
                    acc *= num;
                }
            }

            sum += acc;

            long GetNumber(int column) =>
                Enumerable
                    .Range(0, numbers)
                    .Aggregate(0L, (agg, cur) =>
                    {
                        var str = parts[cur][column].ToString();
                        return str == " "
                            ? agg
                            : agg * 10 + int.Parse(str);
                    });
        }

        return sum;
    }
}