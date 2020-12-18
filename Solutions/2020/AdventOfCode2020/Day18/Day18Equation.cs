using System.Collections.Generic;

namespace AdventOfCode2020.Day18
{
    public class Day18Equation
    {
        private readonly string input;

        // ((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2
        public Day18Equation(string input)
        {
            this.input = input.Replace(" ", string.Empty);
        }

        public long Solve()
        {
            var numbers = new List<long>() { 0L };
            var operations = new List<char>() { '+' };
            var depth = 0;

            foreach (var c in this.input)
            {
                if (long.TryParse(c.ToString(), out var number))
                {
                    var operation = operations[depth];
                    if (operation == '+')
                    {
                        numbers[depth] += number;
                    }
                    else if (operation == '*')
                    {
                        numbers[depth] *= number;
                    }
                }
                else if (c == '+' || c == '*')
                {
                    operations[depth] = c;
                }
                else if (c == '(')
                {
                    numbers.Add(0);
                    operations.Add('+');
                    depth++;
                }
                else if (c == ')')
                {
                    var operation = operations[depth - 1];
                    if (operation == '+')
                    {
                        numbers[depth - 1] += numbers[depth];
                    }
                    else if (operation == '*')
                    {
                        numbers[depth - 1] *= numbers[depth];
                    }

                    numbers.RemoveAt(numbers.Count - 1);
                    operations.RemoveAt(numbers.Count - 1);
                    depth--;
                }
            }

            return numbers[0];
        }
    }
}