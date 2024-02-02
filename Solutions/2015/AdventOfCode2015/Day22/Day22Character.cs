namespace AdventOfCode2015.Day22;

public class Day22Character
{
    public Day22Character(int hitpoints, int mana)
    {
        Hitpoints = hitpoints;
        Mana = mana;
    }

    public Day22Character(string input)
    {
        var splits = input
            .Split(Environment.NewLine)
            .Select(x => x.Split(": ")[1])
            .Select(int.Parse)
            .ToArray();

        Hitpoints = splits[0];
        Damage = splits[1];
    }

    public int Hitpoints { get; set; }

    public int Mana { get; set; }

    public int Damage { get; set; }

    public int Poison { get; set; }

    public int Recharge { get; set; }

    public int Shield { get; set; }

    public bool IsDead => Hitpoints <= 0;

    public bool ApplyEffect()
    {
        if (Poison > 0)
        {
            Hitpoints -= 3;
            Poison--;
        }
        if (Recharge > 0)
        {
            Mana += 101;
            Recharge--;
        }
        if (Shield > 0)
        {
            Shield--;
        }

        return Hitpoints <= 0;
    }

    public void ReceiveDamage(int damage)
    {
        if (Shield > 0)
        {
            damage -= 7;
        }

        Hitpoints -= Math.Max(1, damage);
    }

    public Day22Character Clone()
        => new(Hitpoints, Mana)
        {
            Damage = Damage,
            Poison = Poison,
            Recharge = Recharge,
            Shield = Shield,
        };
}