namespace AdventOfCode2015.Day21;

public class Day21Equipment
{
    // Dagger        8     4       0
    // Damage +1    25     1       0
    public Day21Equipment(string input)
    {
        var splits = input
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Skip(1)
            .Select(int.Parse)
            .ToArray();

        if (splits.Length == 4)
        {
            splits = [.. splits.Skip(1)];
        }

        Cost = splits[0];
        Damage = splits[1];
        Armor = splits[2];
    }

    public int Cost { get; }

    public int Damage { get; }

    public int Armor { get; }
}