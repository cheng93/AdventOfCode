namespace AdventOfCode2022.Day11;

public class Day11Monkey
{
    /*
    Monkey 0:
        Starting items: 79, 98
        Operation: new = old * 19
        Test: divisible by 23
            If true: throw to monkey 2
            If false: throw to monkey 3
    */
    public Day11Monkey(string input)
    {
        var lines = input
            .Split(Environment.NewLine)
            .Select(x => x.Trim())
            .ToArray();

        Id = int.Parse(lines[0].Split(" ")[1][..^1]);
        var items = lines[1]
            .Split(": ")[1]
            .Split(", ")
            .Select(long.Parse);
        Items = new Queue<long>(items);

        operationParts = lines[2]
            .Split("= ")[1]
            .Split(" ");

        Divisor = int.Parse(lines[3].Split(" ")[^1]);
        trueMonkey = int.Parse(lines[4].Split(" ")[^1]);
        falseMonkey = int.Parse(lines[5].Split(" ")[^1]);
    }

    public int Id { get; }

    public Queue<long> Items { get; }

    public int Divisor { get; }

    private string[] operationParts;

    private int trueMonkey;

    private int falseMonkey;

    public long Inspect(long worry)
    {
        var x = GetValue(operationParts[0]);
        var y = GetValue(operationParts[2]);

        return operationParts[1] == "+"
            ? x + y
            : x * y;

        long GetValue(string operationPart)
            => operationPart == "old" ? worry : long.Parse(operationPart);
    }

    public int Throw(long worry)
        => (worry % Divisor) == 0
            ? trueMonkey
            : falseMonkey;
}