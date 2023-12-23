namespace AdventOfCode2023.Day15;

public class Day15Step
{
    // rn=1
    // cm-
    public Day15Step(string input)
    {
        var splits = input.Split(new char[] { '=', '-' }, StringSplitOptions.RemoveEmptyEntries);
        Label = splits[0];
        if (splits.Length > 1)
        {
            Operation = '=';
            Number = int.Parse(splits[1]);
        }
        else
        {
            Operation = '-';
        }
    }

    public string Label { get; }

    public char Operation { get; }

    public int Number { get; }
}