namespace AdventOfCode2015.Day22;

public static class Day22Solver
{
    public static int PuzzleOne(string input) => Solve(input, false);

    public static int PuzzleTwo(string input) => Solve(input, true);

    private static int Solve(string input, bool isHard)
    {
        var queue = new PriorityQueue<(Day22Character Player, Day22Character Boss, int ManaSpent, bool isPlayerTurn), int>();
        queue.Enqueue((new Day22Character(50, 500), new Day22Character(input), 0, true), 0);

        while (queue.Count > 0)
        {
            var (player, boss, manaSpent, isPlayerTurn) = queue.Dequeue();
            if (boss.IsDead)
            {
                return manaSpent;
            }

            if (isHard && isPlayerTurn)
            {
                player.Hitpoints--;
                if (player.IsDead)
                {
                    continue;
                }
            }

            if (player.ApplyEffect())
            {
                continue;
            }
            if (boss.ApplyEffect())
            {
                return manaSpent;
            }
            if (isPlayerTurn)
            {
                if (player.Mana < 53)
                {
                    continue;
                }

                var spells = new Spell[]
                {
                    new MagicMissileSpell(),
                    new DrainSpell(),
                    new ShieldSpell(),
                    new PoisonSpell(),
                    new RechargeSpell()
                };

                foreach (var spell in spells)
                {
                    var newPlayer = player.Clone();
                    var newBoss = boss.Clone();
                    var cost = spell.Cast(newPlayer, newBoss);
                    if (cost > 0)
                    {
                        var newManaSpent = manaSpent + cost;
                        queue.Enqueue((newPlayer, newBoss, newManaSpent, !isPlayerTurn), newManaSpent);

                    }
                }
            }
            else
            {
                var newPlayer = player.Clone();
                newPlayer.ReceiveDamage(boss.Damage);
                if (!newPlayer.IsDead)
                {
                    queue.Enqueue((newPlayer, boss.Clone(), manaSpent, !isPlayerTurn), manaSpent);
                }
            }
        }

        throw new Exception();
    }
}