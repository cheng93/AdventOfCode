using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day06
{
    public class Day06Solver
    {
        public int PuzzleOne(string input)
        {
            var groups = input
                .Split(new[] { $"{Environment.NewLine}{Environment.NewLine}" }, StringSplitOptions.RemoveEmptyEntries);

            var count = 0;
            foreach (var group in groups)
            {
                var lines = group.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var set = new HashSet<char>();
                foreach (var line in lines)
                {
                    foreach (var letter in line)
                    {
                        set.Add(letter);
                    }
                }

                count += set.Count;
            }

            return count;
        }

        public int PuzzleTwo(string input)
        {
            var groups = input
                .Split(new[] { $"{Environment.NewLine}{Environment.NewLine}" }, StringSplitOptions.RemoveEmptyEntries);

            var count = 0;
            foreach (var group in groups)
            {
                var lines = group.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                HashSet<char> set = null;
                foreach (var line in lines)
                {
                    if (set == null)
                    {
                        set = new HashSet<char>(line);
                        continue;
                    }
                    var lineSet = new HashSet<char>(line);
                    set.IntersectWith(lineSet);
                }

                count += set.Count;
            }

            return count;
        }
    }
}