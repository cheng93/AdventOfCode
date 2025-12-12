namespace AdventOfCode2025.Day12;

public class Day12Present
{
    /*
        0:
        ###
        ##.
        ##.
    */
    public Day12Present(string input)
    {
        var splits = input.Split($":{Environment.NewLine}");
        Index = int.Parse(splits[0]);
        Shape = new(splits[1]);
    }
    
    public int Index { get; }
    
    public Day12Shape Shape { get; }
}