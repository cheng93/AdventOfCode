namespace AdventOfCode2015.Day20;

public static class Day20Solver
{
    public static int PuzzleOne(string input)
    {
        var target = int.Parse(input);

        return Enumerable
            .Range(1, int.MaxValue)
            .Select(x => new
            {
                Sum = Factors(x).Sum() * 10,
                Number = x
            })
            .First(x => x.Sum >= target)
            .Number;

        IEnumerable<int> Factors(int n)
        {
            var sqrt = Math.Sqrt(n);
            for (var i = 1; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    yield return i;
                    if (sqrt % i != 0)
                    {
                        yield return n / i;
                    }
                }
            }
        }
    }

    public static int PuzzleTwo(string input)
    {
        var target = int.Parse(input);

        return Enumerable
            .Range(1, int.MaxValue)
            .Select(x => new
            {
                Sum = Factors(x)
                    .OrderBy(x => x)
                    .Take(50)
                    .Sum() * 11,
                Number = x
            })
            .First(x => x.Sum >= target)
            .Number;

        IEnumerable<int> Factors(int n)
        {
            var sqrt = Math.Sqrt(n);
            for (var i = 1; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    if (n / i <= 50)
                    {
                        yield return i;
                    }
                    if (sqrt % i != 0 && i <= 50)
                    {
                        yield return n / i;
                    }
                }
            }
        }
    }
}