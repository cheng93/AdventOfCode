namespace AdventOfCode2016.Day15;

public class Day15Solver
{
    public static int PuzzleOne(IEnumerable<string> input)
    {
        var discs = input.Select(x => Day15Disc.Create(x)).ToArray();

        return Solve(discs);
    }

    public static int PuzzleTwo(IEnumerable<string> input)
    {
        var discs = input.Select(x => Day15Disc.Create(x)).ToList();
        discs.Add(new Day15Disc(11, 0));

        return Solve(discs);
    }

    private static int Solve(ICollection<Day15Disc> discs)
    {
        var time = 0;
        while (true)
        {
            var gotCapsule = discs
                .Select((x, i) => x.PositionAt(time + i + 1) == 0)
                .All(x => x);
            if (gotCapsule)
            {
                return time;
            }
            time++;
        }

        throw new Exception();
    }
}