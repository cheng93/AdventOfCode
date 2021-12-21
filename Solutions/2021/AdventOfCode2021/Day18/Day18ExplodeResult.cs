namespace AdventOfCode2021.Day18;

public class Day18ExplodeResult
{
    private Day18ExplodeResult(bool exploded, int? left = null, int? right = null)
    {
        Exploded = exploded;
        Left = left;
        Right = right;
    }

    public bool Exploded { get; }
    public int? Left { get; set; }
    public int? Right { get; set; }

    public static Day18ExplodeResult NoExplosion() => new Day18ExplodeResult(false);
    public static Day18ExplodeResult Explosion(int left, int right) => new Day18ExplodeResult(true, left, right);
}