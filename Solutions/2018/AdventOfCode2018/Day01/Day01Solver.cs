﻿namespace AdventOfCode2018.Day01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day01Solver
    {
        public int PuzzleOne(IEnumerable<int> input) => input.Sum();

        public int PuzzleTwo(IEnumerable<int> input)
        {
            input = input.ToList();

            var frequencies = new HashSet<int>() { 0 };
            var sum = 0;

            while (true)
            {
                foreach (var number in input)
                {
                    sum += number;
                    if (frequencies.Contains(sum))
                    {
                        return sum;
                    }
                    else
                    {
                        frequencies.Add(sum);
                    }
                }
            }

            throw new Exception();
        }
    }
}
