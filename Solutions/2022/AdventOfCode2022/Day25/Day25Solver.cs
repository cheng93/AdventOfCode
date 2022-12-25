namespace AdventOfCode2022.Day25;

public static class Day25Solver
{
    public static string PuzzleOne(IEnumerable<string> input)
    {
        var sum = 0L;

        foreach (var line in input)
        {
            sum += ToDecimal(line);
        }

        return ToSnafu(sum);

        long ToDecimal(string snafu)
        {
            var x = 0L;
            var factor = 1L;
            for (var i = snafu.Length - 1; i >= 0; i--)
            {
                var c = snafu[i];
                var unit = c switch
                {
                    '=' => -2,
                    '-' => -1,
                    _ => int.Parse(c.ToString())
                };
                x += unit * factor;
                factor *= 5;
            }
            return x;
        }

        string ToSnafu(long number)
        {
            Console.WriteLine(number);
            var snafu = string.Empty;
            while (number > 0)
            {
                var remainder = number % 5;
                var unit = remainder switch
                {
                    3 => -2,
                    4 => -1,
                    _ => remainder
                };
                var snafuUnit = unit switch
                {
                    -2 => '=',
                    -1 => '-',
                    _ => unit.ToString()[0]
                };

                snafu = snafuUnit + snafu;
                number -= unit;
                number /= 5;
            }

            return snafu;
        }
    }
}