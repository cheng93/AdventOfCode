namespace AdventOfCode2025.Day01;

// L68
public class Day01Rotation(string input)
{
    public bool IsRight { get; } = input[0] == 'R';

    public int Distance { get; } = int.Parse(input[1..]);
}