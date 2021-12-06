namespace AdventOfCode2021.Day06;

public static class Day06Solver
{
    public static long PuzzleOne(IEnumerable<int> input) => Simulate(input, 80);

    public static long PuzzleTwo(IEnumerable<int> input) => Simulate(input, 256);

    private static long Simulate(IEnumerable<int> input, int days)
    {
        var birthdays = new long[days];
        var initial = 0L;

        foreach (var number in input)
        {
            birthdays[number]++;
            initial++;
        }

        for (var i = 0; i < days; i++)
        {
            var births = birthdays[i];
            birthdays.TryAdd(i + 7, births);
            birthdays.TryAdd(i + 9, births);
        }

        return birthdays.Sum() + initial;
    }

    private static bool TryAdd(this long[] array, int key, long number)
    {
        if (key >= array.Length)
        {
            return false;
        }
        array[key] += number;
        return true;
    }
}