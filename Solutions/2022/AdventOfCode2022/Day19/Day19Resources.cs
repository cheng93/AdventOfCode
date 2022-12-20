using System.Numerics;

namespace AdventOfCode2022.Day19;

public record Day19Resources(int Ore, int Clay, int Obsidian, int Geode)
    : IAdditionOperators<Day19Resources, Day19Resources, Day19Resources>,
        IAdditiveIdentity<Day19Resources, Day19Resources>,
        ISubtractionOperators<Day19Resources, Day19Resources, Day19Resources>,
        IMultiplyOperators<Day19Resources, Day19Resources, Day19Resources>,
        IMultiplyOperators<Day19Resources, int, Day19Resources>,
        IComparisonOperators<Day19Resources, Day19Resources, bool>
{
    public static readonly Day19Resources[] Resources = new Day19Resources[]
    {
        new(1,0,0,0),
        new(0,1,0,0),
        new(0,0,1,0),
        new(0,0,0,1),
    };

    public static readonly Func<Day19Resources, int>[] Selectors = new[]
    {
        (Day19Resources r) => r.Ore,
        (Day19Resources r) => r.Clay,
        (Day19Resources r) => r.Obsidian,
        (Day19Resources r) => r.Geode,
    };

    public static Day19Resources AdditiveIdentity => new(0, 0, 0, 0);

    public static Day19Resources operator +(Day19Resources left, Day19Resources right)
        => new(left.Ore + right.Ore, left.Clay + right.Clay, left.Obsidian + right.Obsidian, left.Geode + right.Geode);

    public static Day19Resources operator -(Day19Resources left, Day19Resources right)
        => new(left.Ore - right.Ore, left.Clay - right.Clay, left.Obsidian - right.Obsidian, left.Geode - right.Geode);

    public static Day19Resources operator *(Day19Resources left, Day19Resources right)
        => new(left.Ore * right.Ore, left.Clay * right.Clay, left.Obsidian * right.Obsidian, left.Geode * right.Geode);

    public static Day19Resources operator *(Day19Resources left, int right)
        => new(left.Ore * right, left.Clay * right, left.Obsidian * right, left.Geode * right);

    public static bool operator <(Day19Resources left, Day19Resources right)
        => left.Ore < right.Ore
            && left.Clay < right.Clay
            && left.Obsidian < right.Obsidian
            && left.Geode < right.Geode;

    public static bool operator >(Day19Resources left, Day19Resources right)
        => left.Ore > right.Ore
            && left.Clay > right.Clay
            && left.Obsidian > right.Obsidian
            && left.Geode > right.Geode;

    public static bool operator <=(Day19Resources left, Day19Resources right)
        => left.Ore <= right.Ore
            && left.Clay <= right.Clay
            && left.Obsidian <= right.Obsidian
            && left.Geode <= right.Geode;

    public static bool operator >=(Day19Resources left, Day19Resources right)
        => left.Ore >= right.Ore
            && left.Clay >= right.Clay
            && left.Obsidian >= right.Obsidian
            && left.Geode >= right.Geode;
}
