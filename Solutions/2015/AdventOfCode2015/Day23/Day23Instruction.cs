namespace AdventOfCode2015.Day23;

public class Day23Instruction
{
    // hlf r
    // jie r, offset
    public Day23Instruction(string input)
    {
        var splits = input
            .Replace(",", string.Empty)
            .Split(' ');

        Command = splits[0];
        if (int.TryParse(splits[1], out var parsed))
        {
            Offset = parsed;
        }
        else
        {
            Register = splits[1] == "a" ? 0 : 1;
        }
        if (splits.Length == 3)
        {
            Offset = int.Parse(splits[2]);
        }
    }

    public string Command { get; set; }

    public int Register { get; set; }

    public int Offset { get; set; }
}