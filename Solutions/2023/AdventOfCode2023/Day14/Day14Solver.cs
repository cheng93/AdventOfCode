namespace AdventOfCode2023.Day14;

public static class Day14Solver
{
    public static int PuzzleOne(string input)
    {
        var dish = new Day14Dish(input);
        dish.TiltNorth();

        return dish.NorthLoad;
    }

    public static int PuzzleTwo(string input)
    {
        var dish = new Day14Dish(input);
        var limit = 1000000000;
        var seen = new Dictionary<string, int>();
        var breakI = int.MinValue;
        seen[dish.ToString()] = 0;

        for (var i = 1; i <= limit; i++)
        {
            dish.TiltNorth();
            dish.TiltWest();
            dish.TiltSouth();
            dish.TiltEast();

            if (i == breakI)
            {
                break;
            }

            var key = dish.ToString();
            if (seen.TryGetValue(key, out var index))
            {
                if (breakI != int.MinValue)
                {
                    continue;
                }
                var mod = i - index;
                var currentRemainder = i % mod;
                var limitRemainder = limit % mod;
                if (limitRemainder < currentRemainder)
                {
                    limitRemainder += mod;
                }
                breakI = i + limitRemainder - currentRemainder;
            }
            else
            {
                seen.Add(dish.ToString(), i);
            }
        }

        return dish.NorthLoad;
    }
}