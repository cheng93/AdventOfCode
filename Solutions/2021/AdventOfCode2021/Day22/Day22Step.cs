namespace AdventOfCode2021.Day22;

public record Day22Step
{
    private static Day22Cuboid _initializationCuboid = new(new(-50, 50), new(-50, 50), new(-50, 50));

    // example: on x=10..12,y=10..12,z=10..12
    public Day22Step(string input)
    {
        var splits = input.Split(" ");
        On = splits[0] == "on";

        splits = splits[1].Split(",");
        var x = GetRange(splits[0]);
        var y = GetRange(splits[1]);
        var z = GetRange(splits[2]);

        Cuboid = new(x, y, z);

        Day22Range GetRange(string range)
        {
            var s = range[2..].Split("..").Select(int.Parse).ToArray();
            return new(s[0], s[1]);
        }
    }

    public bool On { get; }
    public Day22Cuboid Cuboid { get; }
    public bool Initialization => _initializationCuboid.TotallyContain(Cuboid);
}