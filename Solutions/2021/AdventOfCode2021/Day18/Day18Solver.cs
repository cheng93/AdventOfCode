namespace AdventOfCode2021.Day18;

public static class Day18Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        return input
            .SelectMany(x => IDay18Element.Create(x.GetEnumerator()))
            .Aggregate((agg, cur) => agg.Add(cur))
            .Magnitude;
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var array = input.ToArray();

        var max = int.MinValue;
        for (var i = 0; i < array.Length - 1; i++)
        {
            for (var j = i + 1; j < array.Length; j++)
            {
                var a = array[i];
                var b = array[j];
                max = Math.Max(max, Sum(a, b));
                max = Math.Max(max, Sum(b, a));
            }
        }

        int Sum(params string[] values)
        {
            return values
                .SelectMany(x => IDay18Element.Create(x.GetEnumerator()))
                .Aggregate((agg, cur) => agg.Add(cur))
                .Magnitude;
        }

        return max;
    }
}