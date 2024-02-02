namespace AdventOfCode2015.Day22;

public abstract class Spell
{
    public int Cast(Day22Character caster, Day22Character target)
    {
        if (caster.Mana < Cost)
        {
            return 0;
        }
        CastImpl(caster, target);
        caster.Mana -= Cost;

        return Cost;
    }

    protected abstract int Cost { get; }

    protected abstract void CastImpl(Day22Character caster, Day22Character target);

    protected virtual bool CanCast(Day22Character caster, Day22Character target)
    {
        return true;
    }
}

public class MagicMissileSpell : Spell
{
    protected override int Cost => 53;

    protected override void CastImpl(Day22Character caster, Day22Character target)
    {
        target.ReceiveDamage(4);
    }
}

public class DrainSpell : Spell
{
    protected override int Cost => 73;

    protected override void CastImpl(Day22Character caster, Day22Character target)
    {
        caster.Hitpoints += 2;
        target.ReceiveDamage(2);
    }
}

public class ShieldSpell : Spell
{
    protected override int Cost => 113;

    protected override void CastImpl(Day22Character caster, Day22Character target)
    {
        caster.Shield += 6;
    }

    protected override bool CanCast(Day22Character caster, Day22Character target)
    {
        return caster.Shield == 0;
    }
}

public class PoisonSpell : Spell
{
    protected override int Cost => 173;

    protected override void CastImpl(Day22Character caster, Day22Character target)
    {
        target.Poison += 6;
    }

    protected override bool CanCast(Day22Character caster, Day22Character target)
    {
        return target.Poison == 0;
    }
}

public class RechargeSpell : Spell
{
    protected override int Cost => 229;

    protected override void CastImpl(Day22Character caster, Day22Character target)
    {
        caster.Recharge += 5;
    }

    protected override bool CanCast(Day22Character caster, Day22Character target)
    {
        return caster.Recharge == 0;
    }
}


