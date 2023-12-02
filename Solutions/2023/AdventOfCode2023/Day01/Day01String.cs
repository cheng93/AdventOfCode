namespace AdventOfCode2023.Day01;

public class Day01String(int length)
{
    private int length = length;

    private string text = string.Empty;

    public int? Number
    {
        get => text switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            var x when int.TryParse(x, out var number) && number / 10 == 0 => number,
            _ => null
        };
    }

    public void Add(char c)
    {
        var t = text;
        if (t.Length == length)
        {
            t = t[^(length - 1)..];
        }
        text = $"{t}{c}";
    }
}