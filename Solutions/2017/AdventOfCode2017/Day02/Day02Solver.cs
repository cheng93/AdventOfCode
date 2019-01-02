namespace AdventOfCode2017.Day02
{
    using System;
    using System.Linq;

    public class Day02Solver
    {
        public int PuzzleOne(string input)
        {
            var rows = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day02Row(x));

            var sum = 0;

            foreach (var row in rows)
            {
                var max = int.MinValue;
                var min = int.MaxValue;

                foreach (var number in row.Numbers)
                {
                    if (number > max) max = number;
                    if (number < min) min = number;
                }

                sum += max - min;
            }

            return sum;
        }

        public int PuzzleTwo(string input)
        {
            var rows = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day02Row(x));

            var sum = 0;

            foreach (var row in rows)
            {
                var numbers = row.Numbers.ToList();
                var broke = false;

                for (var i = 0; i < numbers.Count; i++)
                {
                    for (var j = i + 1; j < numbers.Count; j++)
                    {
                        var x = numbers[i];
                        var y = numbers[j];

                        if (x % y == 0)
                        {
                            sum += x / y;
                            broke = true;
                            break;
                        }
                        else if (y % x == 0)
                        {
                            sum += y / x;
                            broke = true;
                            break;
                        }
                    }

                    if (broke) break;
                }
            }

            return sum;
        }
    }
}