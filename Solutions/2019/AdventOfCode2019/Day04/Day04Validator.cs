using System.Linq;

namespace AdventOfCode2019.Day04
{
    public class Day04Validator
    {
        public bool IsValidOne(int input)
        {
            if (input < 100000 || input >= 1000000)
            {
                return false;
            }

            var digits = input.ToString()
                .Select(x => int.Parse(x.ToString()))
                .ToArray();
            var current = int.MinValue;
            var hasAdjacent = false;
            foreach (var digit in digits)
            {
                if (digit < current)
                {
                    return false;
                }
                if (digit == current)
                {
                    hasAdjacent = true;
                }
                current = digit;
            }

            return hasAdjacent;
        }

        public bool IsValidTwo(int input)
        {
            if (input < 100000 || input >= 1000000)
            {
                return false;
            }

            var digits = input.ToString()
                .Select(x => int.Parse(x.ToString()))
                .ToArray();
            var current = int.MinValue;
            var count = Enumerable.Range(0, 9)
                .Select(x => 0)
                .ToArray();
            foreach (var digit in digits)
            {
                if (digit < current)
                {
                    return false;
                }
                count[digit - 1]++;

                current = digit;
            }

            return count.Any(x => x == 2);
        }
    }
}