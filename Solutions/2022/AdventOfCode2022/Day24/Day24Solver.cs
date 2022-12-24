namespace AdventOfCode2022.Day24;

public static class Day24Solver
{
    public static long PuzzleOne(string input) => Solve(input).First();

    public static long PuzzleTwo(string input) => Solve(input).Take(3).Last();

    private static IEnumerable<int> Solve(string input)
    {
        var lines = input.Split(Environment.NewLine).ToArray();

        var map = new HashSet<(int X, int Y)>();
        var rBlizzards = new List<List<(int Start, int Modifier)>>();
        var cBlizzards = new List<List<(int Start, int Modifier)>>();

        int GetModifer(char c) => c switch
        {
            '>' or 'v' => 1,
            '<' or '^' => -1,
            _ => throw new Exception()
        };

        var mapDirections = new[] { '>', 'v', '<', '^' };
        var directions = new (int X, int Y)[]
        {
            (1, 0),
            (0, 1),
            (-1, 0),
            (0, -1)
        };

        var entrance = (X: 0, Y: 0);
        var exit = entrance;
        var maxX = 0;
        var maxY = 0;

        for (var y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            rBlizzards.Add(new List<(int Start, int Modifier)>());
            for (var x = 0; x < line.Length; x++)
            {
                if (y == 0)
                {
                    cBlizzards.Add(new List<(int Start, int Modifier)>());
                }
                var character = line[x];
                if (character == '#')
                {
                    continue;
                }

                var point = (x, y);
                map.Add(point);

                if (y == 0)
                {
                    entrance = point;
                }
                else if (y == lines.Length - 1)
                {
                    exit = point;
                }
                else if (x == 1)
                {
                    maxY++;
                }

                if (y == 1)
                {
                    maxX++;
                }

                if (character != '.')
                {
                    var directionIndex = Array.IndexOf(mapDirections, character);
                    var modifier = GetModifer(character);
                    if (directionIndex % 2 == 0)
                    {
                        rBlizzards[y].Add((x - 1, modifier));
                    }
                    else
                    {
                        cBlizzards[x].Add((y - 1, modifier));
                    }
                }
            }
        }

        var blizzardCache = new Dictionary<(int X, int Y, int Time), bool>();
        var visited = new HashSet<(int X, int Y, int Time)>();

        var totalTime = 0;
        var i = 0;
        while (true)
        {
            totalTime = i % 2 == 0
                ? Move(entrance, exit, totalTime)
                : Move(exit, entrance, totalTime);
            yield return totalTime;
            i++;
        }

        int Move((int X, int Y) start, (int X, int Y) end, int time)
        {
            var queue = new PriorityQueue<(int X, int Y, int Time), int>();
            queue.Enqueue((start.X, start.Y, time), time);

            while (queue.Count > 0)
            {
                var (x, y, t) = queue.Dequeue();
                if ((x, y) == end)
                {
                    return t;
                }

                foreach (var direction in directions.Concat(new[] { (X: 0, Y: 0) }))
                {
                    var newTime = t + 1;
                    var neighbour = (X: x + direction.X, Y: y + direction.Y);
                    var key = (neighbour.X, neighbour.Y, newTime);
                    if (!map.Contains(neighbour) || HasBlizzard(neighbour, newTime) || visited.Contains(key))
                    {
                        continue;
                    }

                    visited.Add(key);
                    queue.Enqueue((neighbour.X, neighbour.Y, newTime), newTime + ManhattanDistance(neighbour, end));
                }
            }
            throw new Exception();
        }

        bool HasBlizzard((int X, int Y) point, int time)
        {
            var cacheKey = (point.X, point.Y, time);
            if (blizzardCache.TryGetValue(cacheKey, out var cached))
            {
                return cached;
            }

            var cBlizzard = cBlizzards[point.X];
            var rBlizzard = rBlizzards[point.Y];

            foreach (var (start, modifier) in rBlizzard)
            {
                var modTime = time % maxX;
                if ((maxX + start + modifier * modTime) % maxX == point.X - 1)
                {
                    blizzardCache[cacheKey] = true;
                    return true;
                }
            }

            foreach (var (start, modifier) in cBlizzard)
            {
                var modTime = time % maxY;
                if ((maxY + start + modifier * modTime) % maxY == point.Y - 1)
                {
                    blizzardCache[cacheKey] = true;
                    return true;
                }
            }

            blizzardCache[cacheKey] = false;
            return false;
        }

        int ManhattanDistance((int X, int Y) a, (int X, int Y) b)
            => Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }
}