namespace AdventOfCode2015.Day02;

public class Day02Dimension
{
    // 2x3x4
    public Day02Dimension(string input)
    {
        var splits = input.Split('x').Select(int.Parse).ToArray();

        var l = splits[0];
        var h = splits[1];
        var w = splits[2];

        var lh = l * h;
        var hw = h * w;
        var wl = w * l;

        SmallestArea = Math.Min(lh, Math.Min(hw, wl));
        SurfaceArea = 2 * (lh + hw + wl);

        SmallestPerimeter = 2 * Math.Min(l + h, Math.Min(h + w, w + l));
        Volume = l * h * w;
    }

    public int SurfaceArea { get; }

    public int SmallestArea { get; }

    public int SmallestPerimeter { get; }

    public int Volume { get; }
}