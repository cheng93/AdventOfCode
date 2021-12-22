namespace AdventOfCode2021.Day21;

public static class Day21Solver
{
    public static int PuzzleOne(int[] input)
    {
        var scores = new[] { 0, 0 };
        var positions = input.ToArray();

        var totalRolls = 0;
        var turn = 0;
        var die = Roll();

        while (true)
        {
            var rolls = die.Skip(totalRolls).Take(3);
            foreach (var roll in rolls)
            {
                var start = positions[turn];
                positions[turn] = (start - 1 + roll) % 10 + 1;

                totalRolls++;
            }
            scores[turn] += positions[turn];
            if (scores[turn] >= 1000)
            {
                return scores[(turn + 1) % 2] * totalRolls;
            }
            turn = (turn + 1) % 2;
        }

        IEnumerable<int> Roll()
        {
            var counter = 0;
            while (true)
            {
                yield return (counter % 100) + 1;
                counter++;
            }
        }
    }

    public static long PuzzleTwo(int[] input)
    {
        var frequencies = new int[10];
        for (var i = 1; i <= 3; i++)
        {
            for (var j = 1; j <= 3; j++)
            {
                for (var k = 1; k <= 3; k++)
                {
                    var sum = i + j + k;
                    frequencies[sum]++;
                }
            }
        }

        var cache = new Dictionary<(int ScoreA, int ScoreB, int PositionA, int PositionB, int Turn), long[]>();

        var game = Simulate(new[] { 0, 0 }, input.ToArray(), 0);
        return Math.Max(game[0], game[1]);

        long[] Simulate(int[] scores, int[] positions, int turn)
        {
            var key = (scores[0], scores[1], positions[0], positions[1], turn);
            if (cache.TryGetValue(key, out var w))
            {
                return w;
            }
            var wins = new[] { 0L, 0L };
            for (var i = 3; i <= 9; i++)
            {
                var copiedScores = scores.ToArray();
                var copiedPositions = positions.ToArray();

                var start = copiedPositions[turn];
                copiedPositions[turn] = (start - 1 + i) % 10 + 1;
                copiedScores[turn] += copiedPositions[turn];
                var multiplier = frequencies[i];
                if (copiedScores[turn] >= 21)
                {
                    wins[turn] += multiplier;
                }
                else
                {
                    var sim = Simulate(copiedScores, copiedPositions, (turn + 1) % 2);
                    wins[0] += multiplier * sim[0];
                    wins[1] += multiplier * sim[1];
                }
            }

            cache.Add(key, wins);
            return wins;
        }
    }
}