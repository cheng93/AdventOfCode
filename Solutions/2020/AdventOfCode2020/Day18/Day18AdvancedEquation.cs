using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day18
{
    public class Day18AdvancedEquation
    {
        private readonly string input;

        // ((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2
        public Day18AdvancedEquation(string input)
        {
            this.input = input.Replace(" ", string.Empty);
        }

        public long Solve()
        {
            var numbers = new List<long>();
            var operations = new List<char>();

            var depth = 0;
            var bracketString = "";
            foreach (var c in this.input)
            {
                if (c == ')')
                {
                    depth--;
                    if (depth == 0)
                    {
                        var number = new Day18AdvancedEquation(bracketString).Solve();
                        if (operations.LastOrDefault() == '+')
                        {
                            numbers[numbers.Count - 1] += number;
                            operations.RemoveAt(numbers.Count - 1);
                        }
                        else
                        {
                            numbers.Add(number);
                        }
                        bracketString = "";
                    }
                }

                if (depth > 0)
                {
                    bracketString += c;
                }
                else if (long.TryParse(c.ToString(), out var number))
                {
                    if (operations.LastOrDefault() == '+')
                    {
                        numbers[numbers.Count - 1] += number;
                        operations.RemoveAt(numbers.Count - 1);
                    }
                    else
                    {
                        numbers.Add(number);
                    }
                }
                else if (c == '+' || c == '*')
                {
                    operations.Add(c);
                }

                if (c == '(')
                {
                    depth++;
                }
            }

            return numbers.Aggregate((agg, cur) => agg * cur);
        }
    }
}