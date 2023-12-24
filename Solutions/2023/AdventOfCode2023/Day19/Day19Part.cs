namespace AdventOfCode2023.Day19;

public class Day19Part
{
    // {x=787,m=2655,a=1222,s=2876}
    public Day19Part(string input)
    {
        var splits = input[1..^1].Split(',');
        var ratings = splits
            .Select(x => x.Split('=')[1])
            .Select(int.Parse)
            .ToArray();

        X = ratings[0];
        M = ratings[1];
        A = ratings[2];
        S = ratings[3];
    }

    public int X { get; }

    public int M { get; }

    public int A { get; }

    public int S { get; }

    public int Rating => X + M + A + S;
}