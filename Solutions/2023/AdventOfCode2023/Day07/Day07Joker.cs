namespace AdventOfCode2023.Day07;

public class Day07Joker(string input) : Day07Hand(input)
{
    public override string Labels => "J23456789TQKA";

    public override int GetHandType()
    {
        var ordered = Value
            .OrderBy(x => x != 'J')
            .ThenByDescending(x => Value.Count(letter => letter == x))
            .ThenBy(x => x);
        var mask = string.Empty;
        var current = ordered.Where(x => x != 'J').FirstOrDefault('J');
        var i = 0;

        foreach (var letter in ordered)
        {
            if (current != letter && letter != 'J')
            {
                current = letter;
                i++;
            }
            mask += i;
        }

        return mask switch
        {
            "00000" => 7,
            "00001" => 6,
            "00011" => 5,
            "00012" => 4,
            "00112" => 3,
            "00123" => 2,
            "01234" => 1,
            _ => throw new Exception()
        };
    }
}