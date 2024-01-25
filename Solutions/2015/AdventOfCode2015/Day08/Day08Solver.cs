namespace AdventOfCode2015.Day08;

public static class Day08Solver
{
    public static int PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var sum = 0;

        foreach (var line in lines)
        {
            sum += line.Length;
            for (var i = 1; i < line.Length - 1; i++)
            {
                var character = line[i];
                if (character == '\\')
                {
                    var next = line[i + 1];
                    if (next == 'x')
                    {
                        i += 3;
                    }
                    else
                    {
                        i++;
                    }
                }
                sum--;
            }
        }

        return sum;
    }

    public static int PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var sum = 0;

        foreach (var line in lines)
        {
            sum += 2;
            for (var i = 0; i < line.Length; i++)
            {
                var character = line[i];
                if (character == '\\' || character == '"')
                {
                    sum++;
                }
            }
        }

        return sum;
    }
}