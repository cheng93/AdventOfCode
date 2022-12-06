namespace AdventOfCode2022.Day06;

public static class Day06Solver
{
    public static int PuzzleOne(string input) => Solve(input, 4);

    public static int PuzzleTwo(string input) => Solve(input, 14);

    private static int Solve(string input, int length)
    {
        for (var i = 0; i < input.Length - length + 1; i++)
        {
            var end = i + length;
            var marker = input[i..end];
            if (marker.Distinct().Count() == length)
            {
                return end;
            }
        }

        throw new System.Exception();
    }
}