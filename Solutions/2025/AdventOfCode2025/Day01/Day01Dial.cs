namespace AdventOfCode2025.Day01;

public class Day01Dial(int initial)
{
    public int Value { get; private set; } = initial;

    public int Rotate(Day01Rotation rotation)
    {
        var rotated = Value + rotation.Distance * (rotation.IsRight ? 1 : -1);
        var quotient = rotation.Distance / 100;
        var oldValue = Value;
        Value = (rotated + (rotation.IsRight ? 0 : (quotient + 1) * 100)) % 100;

        return rotation.IsRight
            ? rotated / 100
            : Math.Abs((rotated - 100
                       + (oldValue == 0 ? 100 : 0)) / 100);
    }
}