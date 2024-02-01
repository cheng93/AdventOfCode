namespace AdventOfCode2015.Day21;

public static class Day21Solver
{
    public static int PuzzleOne(string input)
    {
        var categories = Shop
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(split => split
                .Split(Environment.NewLine)
                .Skip(1)
                .Select(x => new Day21Equipment(x))
                .ToArray())
            .ToArray();

        var weapons = categories[0];
        var armor = categories[1];
        var rings = categories[2];

        var min = int.MaxValue;

        foreach (var weapon in weapons)
        {
            for (var i = -1; i < armor.Length; i++)
            {
                for (var j = -1; j < rings.Length - 1; j++)
                {
                    for (var k = j + 1; k < rings.Length; k++)
                    {
                        var cost = 0;
                        Action<Day21Character> equip = x => { };
                        Equip(equip, weapon);
                        if (i > -1)
                        {
                            Equip(equip, armor[i]);
                        }
                        if (j > -1)
                        {
                            Equip(equip, rings[j]);
                        }
                        GetMin();

                        Equip(equip, rings[k]);
                        GetMin();

                        void Equip(Action<Day21Character> e, Day21Equipment equipment)
                        {
                            cost += equipment.Cost;
                            equip = x => { e(x); x.Equip(equipment); };
                        }

                        void GetMin()
                        {
                            var win = Simulate(new(input), equip);
                            if (win)
                            {
                                min = Math.Min(min, cost);
                            }
                        }
                    }
                }
            }
        }

        return min;
    }

    public static int PuzzleTwo(string input)
    {
        var categories = Shop
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(split => split
                .Split(Environment.NewLine)
                .Skip(1)
                .Select(x => new Day21Equipment(x))
                .ToArray())
            .ToArray();

        var weapons = categories[0];
        var armor = categories[1];
        var rings = categories[2];

        var max = int.MinValue;

        foreach (var weapon in weapons)
        {
            for (var i = -1; i < armor.Length; i++)
            {
                for (var j = -1; j < rings.Length - 1; j++)
                {
                    for (var k = j + 1; k < rings.Length; k++)
                    {
                        var cost = 0;
                        Action<Day21Character> equip = x => { };
                        Equip(equip, weapon);
                        if (i > -1)
                        {
                            Equip(equip, armor[i]);
                        }
                        if (j > -1)
                        {
                            Equip(equip, rings[j]);
                        }
                        GetMax();

                        Equip(equip, rings[k]);
                        GetMax();

                        void Equip(Action<Day21Character> e, Day21Equipment equipment)
                        {
                            cost += equipment.Cost;
                            equip = x => { e(x); x.Equip(equipment); };
                        }

                        void GetMax()
                        {
                            var win = Simulate(new(input), equip);
                            if (!win)
                            {
                                max = Math.Max(max, cost);
                            }
                        }
                    }
                }
            }
        }

        return max;
    }

    private static bool Simulate(Day21Boss boss, Action<Day21Character> equip)
    {
        var player = new Day21Character(100);
        equip(player);
        var i = 0;
        while (true)
        {
            var isPlayerTurn = i % 2 == 0;
            var result = isPlayerTurn
                ? boss.ReceiveDamage(player.Damage)
                : player.ReceiveDamage(boss.Damage);

            if (result)
            {
                return isPlayerTurn;
            }

            i++;
        }
    }

    private const string Shop =
    """
    Weapons:    Cost  Damage  Armor
    Dagger        8     4       0
    Shortsword   10     5       0
    Warhammer    25     6       0
    Longsword    40     7       0
    Greataxe     74     8       0

    Armor:      Cost  Damage  Armor
    Leather      13     0       1
    Chainmail    31     0       2
    Splintmail   53     0       3
    Bandedmail   75     0       4
    Platemail   102     0       5

    Rings:      Cost  Damage  Armor
    Damage +1    25     1       0
    Damage +2    50     2       0
    Damage +3   100     3       0
    Defense +1   20     0       1
    Defense +2   40     0       2
    Defense +3   80     0       3
    """;
}