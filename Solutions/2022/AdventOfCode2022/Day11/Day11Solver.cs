namespace AdventOfCode2022.Day11;

public static class Day11Solver
{
    public static long PuzzleOne(string input)
        => MonkeyBusiness(input, 20, (worry, _) => worry / 3);

    public static long PuzzleTwo(string input)
    {
        long? relief = null;

        return MonkeyBusiness(input, 10000, Relief);

        long Relief(long worry, IEnumerable<Day11Monkey> monkeys)
        {
            if (!relief.HasValue)
            {
                relief = monkeys
                    .Select(x => x.Divisor)
                    .Aggregate(1L, (agg, cur) => agg * cur);
            }

            return worry %= relief.Value;
        }
    }

    private static long MonkeyBusiness(string input, int rounds, Func<long, IEnumerable<Day11Monkey>, long> relief)
    {
        var monkeys = input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => new Day11Monkey(x))
            .ToArray();

        var inspections = monkeys.Select(x => 0L).ToArray();

        for (var i = 0; i < rounds; i++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.Items.Any())
                {
                    var worry = monkey.Items.Dequeue();
                    worry = monkey.Inspect(worry);
                    inspections[monkey.Id]++;
                    worry = relief(worry, monkeys);
                    var next = monkey.Throw(worry);
                    monkeys[next].Items.Enqueue(worry);
                }
            }
        }

        return inspections
            .OrderByDescending(x => x)
            .Take(2)
            .Aggregate((agg, cur) => agg * cur);
    }
}