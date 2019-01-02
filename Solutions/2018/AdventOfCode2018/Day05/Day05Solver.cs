namespace AdventOfCode2018.Day05
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Day05Solver
    {
        public int PuzzleOne(string input)
        {
            var stack = new Stack<char>();
            foreach (var letter in input)
            {
                if (stack.Count == 0)
                {
                    stack.Push(letter);
                }
                else
                {
                    var top = stack.Peek();
                    if ((char.IsUpper(top) && !char.IsUpper(letter) || !char.IsUpper(top) && char.IsUpper(letter))
                            && string.Equals(top.ToString(), letter.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(letter);
                    }
                }
            }

            return stack.Count;
        }

        public int PuzzleTwo(string input)
        {
            var polymers = Enumerable.Range('A', 'Z' - 'A' + 1).Select(x => (char) x);

            var result = int.MaxValue;

            foreach (var polymer in polymers)
            {
                var reduced = Regex.Replace(input, polymer.ToString(), "", RegexOptions.IgnoreCase);
                var stack = new Stack<char>();
                foreach (var letter in reduced)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(letter);
                    }
                    else
                    {
                        var top = stack.Peek();
                        if ((char.IsUpper(top) && !char.IsUpper(letter) || !char.IsUpper(top) && char.IsUpper(letter))
                            && string.Equals(top.ToString(), letter.ToString(),
                                StringComparison.InvariantCultureIgnoreCase))
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(letter);
                        }
                    }
                }

                if (stack.Count < result)
                {
                    result = stack.Count;
                }
            }

            return result;
        }
    }
}