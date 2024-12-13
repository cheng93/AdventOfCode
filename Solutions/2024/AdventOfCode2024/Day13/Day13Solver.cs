namespace AdventOfCode2024.Day13;

public static class Day13Solver
{
    public static long PuzzleOne(string input) => Solve(input, 0);

    public static long PuzzleTwo(string input) => Solve(input, 10000000000000);

    private static long Solve(string input, long adjustment)
    {
        return input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => new Day13Machine(x))
            .Sum(GetMinimumToken);

        long GetMinimumToken(Day13Machine machine)
        {
            var determinant = machine.A.X * machine.B.Y - machine.A.Y * machine.B.X;
            if (determinant == 0)
            {
                return 0;
            }
            var xPrize = machine.Prize.X + adjustment;
            var yPrize = machine.Prize.Y + adjustment;
            var aNumerator = machine.B.Y * xPrize - machine.B.X * yPrize;
            var bNumerator = machine.A.X * yPrize - machine.A.Y * xPrize;
            if (aNumerator % determinant == 0 && bNumerator % determinant == 0)
            {
                return aNumerator / determinant * 3 + bNumerator / determinant;
            }

            return 0;
        }
    }
}