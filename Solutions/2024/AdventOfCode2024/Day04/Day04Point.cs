namespace AdventOfCode2024.Day04;

public record Day04Point(int Row, int Column)
{
    public Day04Point Down() => this with { Column = Column + 1 };

    public Day04Point Left() => this with { Row = Row - 1 };

    public Day04Point Right() => this with { Row = Row + 1 };

    public Day04Point Up() => this with { Column = Column - 1 };
}