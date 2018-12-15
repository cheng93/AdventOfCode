namespace AdventOfCode2018.Day14
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day14Solver
    {
        public string PuzzleOne(int input)
        {
            var elves = new int[] { 0, 1 };
            var scores = new List<int>() { 3, 7 };

            while (scores.Count < input + 10)
            {
                var newScore = scores[elves[0]] + scores[elves[1]];
                if (newScore < 10)
                {
                    scores.Add(newScore);
                }
                else
                {
                    scores.Add(1);
                    scores.Add(newScore % 10);
                }

                for (var i = 0; i < elves.Length; i++)
                {
                    var elfScore = scores[elves[i]];
                    var newPosition = (elfScore + 1 + elves[i]) % scores.Count;
                    elves[i] = newPosition;
                }
            }

            return string.Join("", scores.Skip(input).Take(10));
        }
        public int PuzzleTwo(string input)
        {
            var elves = new int[] { 0, 1 };
            var scores = new List<int>() { 3, 7 };

            var builder = string.Empty;

            while (true)
            {
                var newScore = scores[elves[0]] + scores[elves[1]];
                if (newScore < 10)
                {
                    scores.Add(newScore);
                }
                else
                {
                    scores.Add(1);
                    scores.Add(newScore % 10);
                }

                for (var i = 0; i < elves.Length; i++)
                {
                    var elfScore = scores[elves[i]];
                    var newPosition = (elfScore + 1 + elves[i]) % scores.Count;
                    elves[i] = newPosition;
                }

                builder += newScore.ToString();
                if (builder.Length >= input.Length)
                {
                    for (var i = 0; i <= (newScore / 10) % 10; i++)
                    {
                        if (input == builder.Substring(0, input.Length))
                        {
                            return scores.Count - newScore.ToString().Length - input.Length + 1 + i;
                        }
                        builder = builder.Substring(1);
                    }
                }
            }
        }
    }
}