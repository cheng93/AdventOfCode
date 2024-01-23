namespace AdventOfCode2015.Day01;

public static class Day01Solver
{
    public static int PuzzleOne(string input)
        => input.Aggregate(0, (agg, cur) => cur switch
        {
            '(' => agg + 1,
            ')' => agg - 1,
            _ => throw new Exception()
        });

    public static int PuzzleTwo(string input)
    {
        var floor = 0;
        for (var i = 0; i < input.Length; i++)
        {
            floor = input[i] switch
            {
                '(' => floor + 1,
                ')' => floor - 1,
                _ => throw new Exception()
            };
            if (floor < 0)
            {
                return i + 1;
            }
        }

        throw new Exception();
    }
}