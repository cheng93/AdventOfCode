using System;

namespace AdventOfCode2020.Day05
{
    public class Day05Scanner
    {
        public int Scan(string input)
        {
            var row = GetPartition(input[..7]);
            var column = GetPartition(input[7..].Replace('R', 'B').Replace('L', 'F'));
            return row * 8 + column;
        }

        private static int GetPartition(string input)
        {
            var min = 0;
            var max = (int)Math.Pow(2, input.Length) - 1;

            foreach (var letter in input)
            {
                var diff = (max + 1 - min) / 2;
                if (letter == 'F')
                {
                    max -= diff;
                }
                else if (letter == 'B')
                {
                    min += diff;
                }
            }

            return min;
        }
    }
}