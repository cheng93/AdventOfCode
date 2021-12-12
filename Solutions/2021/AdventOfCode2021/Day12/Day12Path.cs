namespace AdventOfCode2021.Day12;

public record Day12Path
{
    // example: start-A
    public Day12Path(string input)
    {
        var splits = input.Split("-");
        Start = splits[0];
        End = splits[1];
    }

    public string Start { get; }
    public string End { get; }

    public IEnumerable<(string Start, string End)> ToMap()
    {
        yield return (Start, End);
        yield return (End, Start);
    }
}