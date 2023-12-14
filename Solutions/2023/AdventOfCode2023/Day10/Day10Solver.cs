namespace AdventOfCode2023.Day10;

using Coord = (int X, int Y);

public static class Day10Solver
{
    public static int PuzzleOne(string input) => Solve(input).First();

    public static int PuzzleTwo(string input) => Solve(input).Last();

    private static IEnumerable<int> Solve(string input)
    {
        var sketch = new Day10Sketch(input);
        var pipes = new Dictionary<char, IDay10Pipe>()
        {
            { '|', new Day10VerticalPipe() },
            { '-', new Day10HorizontalPipe() },
            { 'L', new Day10LPipe() },
            { 'J', new Day10JPipe() },
            { '7', new Day10SevenPipe() },
            { 'F', new Day10FPipe() },
        };
        var directionCoords = new Coord[]
        {
            (0, -1), (1, 0), (0, 1), (-1, 0)
        };

        char? s = null;
        var path = new List<Coord>();

        foreach (var (key, initialPipe) in pipes)
        {
            var position = sketch.Start;
            var direction = initialPipe.Initial;
            var steps = 0;
            path.Clear();

            while (true)
            {
                if (sketch.Map.TryGetValue(position, out var p)
                    && (pipes.TryGetValue(p, out var pipe) || p == 'S'))
                {
                    pipe ??= initialPipe;
                    var newDirection = pipe.GetDirection(direction);
                    if (!newDirection.HasValue)
                    {
                        break;
                    }

                    direction = newDirection.Value;
                    if (position == sketch.Start && steps != 0)
                    {
                        yield return (steps + 1) / 2;
                        s = key;
                        break;
                    }

                    var add = directionCoords[direction];
                    position = (position.X + add.X, position.Y + add.Y);
                    path.Add(position);
                    steps++;
                }
                else
                {
                    break;
                }
            }

            if (s.HasValue)
            {
                break;
            }
        }

        var xs = path.Select(coord => coord.X).ToList();
        var ys = path.Select(coord => coord.Y).ToList();
        var toggles = new HashSet<char> { '|', 'L', 'J' };
        var inside = 0;

        for (var y = ys.Min(); y <= ys.Max(); y++)
        {
            var rayIn = false;
            for (var x = xs.Min(); x <= xs.Max(); x++)
            {
                var coord = (x, y);
                var character = sketch.Map[coord];
                if (character == 'S')
                {
                    character = s!.Value;
                }
                if (path.Contains(coord))
                {
                    if (toggles.Contains(character))
                    {
                        rayIn = !rayIn;
                    }
                }
                else if (rayIn)
                {
                    inside++;
                }
            }
        }

        yield return inside;
    }
}