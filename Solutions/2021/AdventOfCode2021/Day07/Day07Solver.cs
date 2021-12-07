namespace AdventOfCode2021.Day07;

public static class Day07Solver
{
    public static int PuzzleOne(IEnumerable<int> input) => Calculate(input, (i) => i);

    public static int PuzzleTwo(IEnumerable<int> input)
    {
        int Triangle(int n) => n * (n + 1) / 2;

        return Calculate(input, Triangle);
    }

    private static int Calculate(IEnumerable<int> input, Func<int, int> func)
    {
        var list = input.ToList();
        var fuel = int.MaxValue;

        for (var i = 0; i <= list.Max(); i++)
        {
            var positionFuels = 0;
            foreach (var number in list)
            {
                positionFuels += func(Math.Abs(number - i));
            }

            if (positionFuels < fuel)
            {
                fuel = positionFuels;
            }
        }

        return fuel;
    }
}