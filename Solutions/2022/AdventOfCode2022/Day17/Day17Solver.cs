namespace AdventOfCode2022.Day17;

public static class Day17Solver
{
    public static long PuzzleOne(string input) => Solve(input, 2022);

    public static long PuzzleTwo(string input) => Solve(input, 1000000000000);

    private static long Solve(string input, long goal)
    {
        var jets = input
            .Select<char, Func<IEnumerable<(int X, int Y)>, IEnumerable<(int X, int Y)>>>(x => x == '<' ? MoveLeft : MoveRight)
            .ToArray();

        var factories = new[]
        {
            Day17RockFactory.Horizontal,
            Day17RockFactory.Plus,
            Day17RockFactory.L,
            Day17RockFactory.Vertical,
            Day17RockFactory.Square,
        };

        var heights = new List<int>();
        var columnHeights = new int[7];

        var stopped = new HashSet<(int X, int Y)>();
        var rockHash = Enumerable.Range(0, factories.Length)
            .Select(x => new List<string>())
            .ToArray();

        goal--;
        var rocks = 0;
        var tick = 0;
        var rock = factories[rocks](0);
        while (rocks < Math.Min(goal, int.MaxValue))
        {
            var jetMod = tick % jets.Length;
            var jet = jets[jetMod];
            var newRock = jet(rock);
            if (IsValid(newRock))
            {
                rock = newRock;
            }
            newRock = MoveDown(rock);
            if (IsValid(newRock))
            {
                rock = newRock;
            }
            else
            {
                var height = heights.Count > 0 ? heights[rocks - 1] : int.MinValue;
                foreach (var point in rock)
                {
                    stopped.Add(point);
                    for (var i = 0; i < 7; i++)
                    {
                        if (i == point.X)
                        {
                            columnHeights[i] = Math.Max(columnHeights[i], point.Y);
                            height = Math.Max(height, point.Y);
                        }
                    }
                }
                heights.Add(height);
                var hash = string.Join(",", columnHeights.Select(x => height - x));
                hash += $",{jetMod}";
                var rockMod = rocks % factories.Length;
                if (rockHash[rockMod].Contains(hash))
                {
                    var initial = factories.Length * rockHash[rockMod].IndexOf(hash) + rockMod;
                    var diff = rocks - initial;
                    goal = goal - initial;
                    var quotient = goal / diff;
                    var remainder = goal % diff;

                    return quotient * (heights[rocks] - heights[initial]) + heights[initial + (int)remainder];
                }
                rockHash[rockMod].Add(hash);
                rocks++;
                rock = factories[rocks % factories.Length](height);
            }
            tick++;
        }

        return heights[(int)goal];

        IEnumerable<(int X, int Y)> Move(IEnumerable<(int X, int Y)> rock, (int X, int Y) by)
        {
            return rock.Select(x => (x.X + by.X, x.Y + by.Y));
        }

        IEnumerable<(int X, int Y)> MoveLeft(IEnumerable<(int X, int Y)> rock) => Move(rock, (-1, 0));
        IEnumerable<(int X, int Y)> MoveRight(IEnumerable<(int X, int Y)> rock) => Move(rock, (1, 0));
        IEnumerable<(int X, int Y)> MoveDown(IEnumerable<(int X, int Y)> rock) => Move(rock, (0, -1));

        bool IsValid(IEnumerable<(int X, int Y)> rock)
            => rock.All(x => !stopped.Contains(x) && x.X is (>= 0 and < 7) && x.Y >= 1);
    }
}