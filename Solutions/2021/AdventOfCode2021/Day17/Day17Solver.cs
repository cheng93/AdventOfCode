namespace AdventOfCode2021.Day17;

public static class Day17Solver
{
    public static int PuzzleOne(string input)
    {
        var targets = input
            .Substring("target area: ".Length)
            .Split(", ")
            .Select(x => new Day17Target(x[2..]))
            .ToArray();

        var yTarget = targets[1];

        var yAbs = Math.Abs(yTarget.Min);
        return yAbs * (yAbs - 1) / 2;
    }

    public static int PuzzleTwo(string input)
    {
        var targets = input
            .Substring("target area: ".Length)
            .Split(", ")
            .Select(x => new Day17Target(x[2..]))
            .ToArray();

        var xTarget = targets[0];
        var yTarget = targets[1];

        var xMin = 0;
        var xTotal = 0;
        while (xTotal < xTarget.Min || xTotal > xTarget.Max)
        {
            xMin++;
            xTotal = xMin * (xMin + 1) / 2;
        }

        var yMax = Math.Abs(yTarget.Min) - 1;
        var hits = 0;

        for (var i = xMin; i <= xTarget.Max; i++)
        {
            for (var j = yTarget.Min; j <= yMax; j++)
            {
                if (IsHit((i, j)))
                {
                    hits++;
                }
            }
        }

        return hits;

        bool IsHit((int X, int Y) velocity)
        {
            var x = 0;
            var y = 0;
            while (true)
            {
                x += velocity.X;
                y += velocity.Y;
                if (y < yTarget.Min || x > xTarget.Max)
                {
                    return false;
                }
                else if (x >= xTarget.Min
                    && x <= xTarget.Max
                    && y >= yTarget.Min
                    && y <= yTarget.Max)
                {
                    return true;
                }
                velocity = (Math.Max(velocity.X - 1, 0), velocity.Y - 1);
            }
        }
    }
}