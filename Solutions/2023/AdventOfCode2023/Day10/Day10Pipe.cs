namespace AdventOfCode2023.Day10;

public interface IDay10Pipe
{
    public int Initial { get; }

    int? GetDirection(int incomingDirection);
}

public class Day10VerticalPipe : IDay10Pipe
{
    public int Initial => 0;

    public int? GetDirection(int incomingDirection)
        => incomingDirection switch
        {
            0 => 0,
            2 => 2,
            _ => null
        };
}

public class Day10HorizontalPipe : IDay10Pipe
{
    public int Initial => 1;

    public int? GetDirection(int incomingDirection)
        => incomingDirection switch
        {
            1 => 1,
            3 => 3,
            _ => null
        };
}

public class Day10LPipe : IDay10Pipe
{
    public int Initial => 2;

    public int? GetDirection(int incomingDirection)
        => incomingDirection switch
        {
            2 => 1,
            3 => 0,
            _ => null
        };
}

public class Day10JPipe : IDay10Pipe
{
    public int Initial => 1;

    public int? GetDirection(int incomingDirection)
        => incomingDirection switch
        {
            1 => 0,
            2 => 3,
            _ => null
        };
}

public class Day10SevenPipe : IDay10Pipe
{
    public int Initial => 0;

    public int? GetDirection(int incomingDirection)
        => incomingDirection switch
        {
            0 => 3,
            1 => 2,
            _ => null
        };
}

public class Day10FPipe : IDay10Pipe
{
    public int Initial => 0;

    public int? GetDirection(int incomingDirection)
        => incomingDirection switch
        {
            0 => 1,
            3 => 2,
            _ => null
        };
}
