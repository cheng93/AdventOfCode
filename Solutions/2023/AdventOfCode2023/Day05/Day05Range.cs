namespace AdventOfCode2023.Day05;

public class Day05Range
{
    // input: 50 98 2
    public Day05Range(string input)
    {
        var values = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();

        Destination = values[0];
        Source = values[1];
        Length = values[2];
    }

    public long Destination { get; set; }

    public long Source { get; set; }

    public long Length { get; set; }
}