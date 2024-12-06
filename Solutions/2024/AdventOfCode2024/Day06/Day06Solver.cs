namespace AdventOfCode2024.Day06;

public static class Day06Solver
{
    public static int PuzzleOne(string input)
    {
        var splits = input.Split(Environment.NewLine);
        var grid = new Dictionary<Day06Point, char>();
        var visited = new HashSet<Day06Point>();

        var moves = new Func<Day06Point, Day06Point>[] {
            x => x.Up(),
            x => x.Right(),
            x => x.Down(),
            x => x.Left(),
        };
        var move = 0;

        for (var i = 0; i < splits.Length; i++)
        {
            for (var j = 0; j < splits[i].Length; j++)
            {
                var c = splits[i][j];
                grid.Add(new(i, j), c);
                if (c == '^')
                {
                    visited.Add(new(i, j));
                }
            }
        }
        var current = visited.First();
        while (grid.ContainsKey(current))
        {
            visited.Add(current);
            move = Enumerable
                .Range(move, moves.Length)
                .Select(x => x % moves.Length)
                .First(x => !grid.TryGetValue(moves[x](current), out var c) || c != '#');

            current = moves[move](current);
        }

        return visited.Count;
    }

    public static int PuzzleTwo(string input)
    {
        var splits = input.Split(Environment.NewLine);
        var grid = new Dictionary<Day06Point, char>();
        var visited = new HashSet<Day06Point>();

        var moves = new Func<Day06Point, Day06Point>[] {
            x => x.Up(),
            x => x.Right(),
            x => x.Down(),
            x => x.Left(),
        };
        var move = 0;

        for (var i = 0; i < splits.Length; i++)
        {
            for (var j = 0; j < splits[i].Length; j++)
            {
                var c = splits[i][j];
                grid.Add(new(i, j), c);
                if (c == '^')
                {
                    visited.Add(new(i, j));
                }
            }
        }
        var first = visited.First();
        var current = first;

        var seen = new HashSet<(Day06Point, int)>();
        var placedObstacles = 0;
        while (grid.ContainsKey(current))
        {
            seen.Add((current, move));
            visited.Add(current);
            move = Enumerable
                .Range(move, moves.Length)
                .Select(x => x % moves.Length)
                .First(x => !grid.TryGetValue(moves[x](current), out var c) || c != '#');

            var placedObstacle = moves[move](current);
            if (placedObstacle != first
                && !visited.Contains(placedObstacle)
                && grid.ContainsKey(placedObstacle))
            {
                var newCurrent = current;
                var newMove = move;
                var newSeen = new HashSet<(Day06Point, int)>(seen);

                while (grid.ContainsKey(newCurrent))
                {
                    newSeen.Add((newCurrent, newMove));
                    newMove = Enumerable
                        .Range(newMove, moves.Length)
                        .Select(x => x % moves.Length)
                        .First(x =>
                        {
                            var next = moves[x](newCurrent);
                            return next != placedObstacle && (!grid.TryGetValue(next, out var c) || c != '#');
                        });

                    newCurrent = moves[newMove](newCurrent);
                    if (newSeen.Contains((newCurrent, newMove)))
                    {
                        placedObstacles++;
                        break;
                    }
                }
            }

            current = moves[move](current);
        }

        return placedObstacles;
    }
}