namespace AdventOfCode2016.Day22;

public class Day22Node
{
    /// dev/grid/node-x0-y0     94T   65T    29T   69%
    public Day22Node(string input)
    {
        var splits = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        FileSystem = splits[0];
        var fileSystemSplits = FileSystem.Split("-");
        var x = int.Parse(fileSystemSplits[1][1..]);
        var y = int.Parse(fileSystemSplits[2][1..]);
        Location = (x, y);
        Size = int.Parse(splits[1][..^1]);
        Used = int.Parse(splits[2][..^1]);
    }

    public string FileSystem { get; }

    public (int X, int Y) Location { get; }

    public int Size { get; }

    public int Used { get; set; }

    public int Available => Size - Used;
}