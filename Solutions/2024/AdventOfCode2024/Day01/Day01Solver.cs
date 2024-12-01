namespace AdventOfCode2024.Day01;

public static class Day01Solver
{
    public static int PuzzleOne(string input)
    {
        var pairs = input
            .Split(Environment.NewLine)
            .Select(x => new Day01Pair(x));

        var left = new List<int>();
        var right = new List<int>();

        foreach (var pair in pairs)
        {
            left.Add(pair.Left);
            right.Add(pair.Right);
        }
        left.Sort();
        right.Sort();

        return left
            .Select((x, i) => Math.Abs(x - right[i]))
            .Sum();
    }

    public static int PuzzleTwo(string input)
    {
        var pairs = input
            .Split(Environment.NewLine)
            .Select(x => new Day01Pair(x));

        var sum = 0;

        var left = new Dictionary<int, int>();
        var right = new Dictionary<int, int>();

        foreach (var pair in pairs)
        {
            if (!left.ContainsKey(pair.Left))
            {
                left[pair.Left] = 0;
            }
            left[pair.Left]++;
            sum += pair.Left * (right.TryGetValue(pair.Left, out var r) ? r : 0);

            if (!right.ContainsKey(pair.Right))
            {
                right[pair.Right] = 0;
            }
            right[pair.Right]++;
            sum += pair.Right * (left.TryGetValue(pair.Right, out var l) ? l : 0);
        }

        return sum;
    }
}