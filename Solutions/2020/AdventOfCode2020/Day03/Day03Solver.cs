using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCode2020.Day03
{
    public class Day03Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var count = 0;
            var width = lines[0].Length;

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var c = line[(i * 3) % width];
                if (c == '#')
                {
                    count++;
                }
            }

            return count;
        }
        public long PuzzleTwo(string input)
        {
            var lines = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var modifierX = new[] { 1, 1, 1, 1, 2 };
            var modifierY = new[] { 1, 3, 5, 7, 1 };
            var counts = new int[5];
            var width = lines[0].Length;

            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = 0; j < modifierY.Length; j++)
                {
                    if (i % modifierX[j] != 0)
                    {
                        continue;
                    }
                    var line = lines[i];
                    var c = line[(i / modifierX[j] * modifierY[j]) % width];
                    if (c == '#')
                    {
                        counts[j]++;
                    }
                }
            }

            return counts.Aggregate(1L, (prev, cur) => prev * cur);
        }
    }
}