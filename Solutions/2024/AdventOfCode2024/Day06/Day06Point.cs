namespace AdventOfCode2024.Day06;

public record Day06Point(int Row, int Column)
{
    public Day06Point Down() => this with { Row = Row + 1 };

    public Day06Point Left() => this with { Column = Column - 1 };

    public Day06Point Right() => this with { Column = Column + 1 };

    public Day06Point Up() => this with { Row = Row - 1 };
}