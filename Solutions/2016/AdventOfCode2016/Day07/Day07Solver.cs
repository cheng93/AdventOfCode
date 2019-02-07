namespace AdventOfCode2016.Day07
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day07Solver
    {
        public int PuzzleOne(string input)
        {
            var ips = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day07IP(x));

            return ips
                .Where(x => !HasAbba(x.Hypernets) && HasAbba(x.Supernets))
                .Count();
        }

        public int PuzzleTwo(string input)
        {
            var ips = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day07IP(x));

            var count = 0;

            foreach (var ip in ips)
            {
                var isSsl = false;
                foreach (var supernet in ip.Supernets)
                {
                    for (var i = 0; i < supernet.Length - 2; i++)
                    {
                        var threeLetters = string.Join("", Enumerable.Range(i, 3).Select(x => supernet[x]));
                        if (IsAba(threeLetters))
                        {
                            var bab = $"{threeLetters[1]}{threeLetters[0]}{threeLetters[1]}";
                            if (ip.Hypernets.Any(x => x.Contains(bab)))
                            {
                                isSsl = true;
                                break;
                            }
                        }
                    }
                    if (isSsl)
                    {
                        count++;
                        break;
                    }
                }
            }

            return count;
        }

        private static bool IsAbba(string input)
            => $"{input[0]}{input[1]}" == $"{input[3]}{input[2]}"
                && input[0] != input[1];

        private static bool HasAbba(IEnumerable<string> inputs)
        {
            foreach (var input in inputs)
            {
                for (var i = 0; i < input.Length - 3; i++)
                {
                    var fourLetters = string.Join("", Enumerable.Range(i, 4).Select(x => input[x]));
                    if (IsAbba(fourLetters))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsAba(string input)
            => input[0] == input[2]
                && input[0] != input[1];
    }
}