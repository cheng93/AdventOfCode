namespace AdventOfCode2025.Day03;

public static class Day03Solver
{
    public static long PuzzleOne(string input) => Solve(input, 2);

    public static long PuzzleTwo(string input) => Solve(input, 12);

    private static long Solve(string input, int length)
    {
        var banks = input
            .Split(Environment.NewLine)
            .Select(x => new Day03Bank(x));

        return banks.Sum(MaxJoltage);

        long MaxJoltage(Day03Bank bank)
        {
            var joltages = new List<long>();
            for (var i = 0; i < bank.Batteries.Length; i++)
            {
                var battery = bank.Batteries[i];

                if (joltages.Count == 0)
                {
                    joltages.Add(battery);
                }
                else if (joltages.Count < length)
                {
                    joltages.Add(NewJoltage(joltages.Last()));
                }

                for (var j = joltages.Count - 1; j >= 0; j--)
                {
                    if (j == 0)
                    {
                        joltages[0] = Math.Max(joltages.First(), battery);
                    }
                    else
                    {
                        joltages[j] = Math.Max(joltages[j], NewJoltage(joltages[j-1]));
                    }
                }

                long NewJoltage(long joltage) => joltage * 10 + battery;
            }
            return joltages.Last();
        }
    }
}