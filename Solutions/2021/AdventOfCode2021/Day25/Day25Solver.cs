namespace AdventOfCode2021.Day25;

public static class Day25Solver
{
    public static int PuzzleOne(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var east = new HashSet<(int X, int Y)>();
        var south = new HashSet<(int X, int Y)>();

        int maxX = 0;
        for (var j = 0; j < lines.Length; j++)
        {
            var line = lines[j];
            maxX = line.Length;
            for (var i = 0; i < maxX; i++)
            {
                var cucumber = line[i];
                if (cucumber == '>')
                {
                    east.Add((i, j));
                }
                else if (cucumber == 'v')
                {
                    south.Add((i, j));
                }
            }
        }

        var steps = 0;
        while (true)
        {
            steps++;
            var eastMoves = new List<((int X, int Y) Source, (int X, int Y) Target)>();
            var southMoves = new List<((int X, int Y) Source, (int X, int Y) Target)>();

            foreach (var cucumber in east)
            {
                var target = ((cucumber.X + 1) % maxX, cucumber.Y);
                if (!east.Contains(target) && !south.Contains(target))
                {
                    eastMoves.Add((cucumber, target));
                }
            }

            foreach (var move in eastMoves)
            {
                east.Remove(move.Source);
                east.Add(move.Target);
            }

            foreach (var cucumber in south)
            {
                var target = (cucumber.X, (cucumber.Y + 1) % lines.Length);
                if (!east.Contains(target) && !south.Contains(target))
                {
                    southMoves.Add((cucumber, target));
                }
            }

            foreach (var move in southMoves)
            {
                south.Remove(move.Source);
                south.Add(move.Target);
            }

            if (!eastMoves.Any() && !southMoves.Any())
            {
                break;
            }
        }
        return steps;
    }
}