namespace AdventOfCode2023.Day01;

public static class Day01Solver
{
    public static int PuzzleOne(string input)
    {
        return input
            .Split(Environment.NewLine)
            .Select(line =>
            {
                var numbers = line
                    .Select(x => x.ToString())
                    .Where(x => int.TryParse(x, out _))
                    .Select(int.Parse);

                return numbers.First() * 10 + numbers.Last();
            }).
            Sum();
    }

    public static int PuzzleTwo(string input)
    {
        var lines = input.Split(Environment.NewLine);

        var strs = Enumerable.Range(1, 5).Select(x => new Day01String(x)).ToList();
        var sum = 0;

        foreach (var line in lines)
        {
            var numbers = new List<int>();
            foreach (var character in line)
            {
                foreach (var str in strs)
                {
                    str.Add(character);

                    if (str.Number.HasValue)
                    {
                        numbers.Add(str.Number.Value);
                    }
                }
            }

            sum += numbers.First() * 10 + numbers.Last();
        }

        return sum;
    }
}