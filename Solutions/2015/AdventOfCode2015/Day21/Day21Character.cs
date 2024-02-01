namespace AdventOfCode2015.Day21;

public class Day21Character
{
    public Day21Character(int hitpoints)
    {
        Hitpoints = hitpoints;
    }

    public int Hitpoints { get; protected set; }

    public int Damage { get; set; }

    public int Armor { get; set; }

    public bool ReceiveDamage(int damage)
    {
        Hitpoints -= Math.Max(1, damage - Armor);
        return Hitpoints <= 0;
    }

    public void Equip(Day21Equipment equipment)
    {
        Damage += equipment.Damage;
        Armor += equipment.Armor;
    }
}

public class Day21Boss : Day21Character
{
    public Day21Boss(string input) : base(0)
    {
        var splits = input
            .Split(Environment.NewLine)
            .Select(x => x.Split(": ")[1])
            .Select(int.Parse)
            .ToArray();

        Hitpoints = splits[0];
        Damage = splits[1];
        Armor = splits[2];
    }
}