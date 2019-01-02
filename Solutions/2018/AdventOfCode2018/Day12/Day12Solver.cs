namespace AdventOfCode2018.Day12
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Day12Solver
    {
        public int PuzzleOne(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var initialState = lines[0].Substring("initial state: ".Length);
            var state = $"....{initialState}....";

            var rules = new Dictionary<string, bool>();
            foreach (var line in lines.Skip(1))
            {
                var pattern = line.Substring(0, 5);
                var hasPlant = line.Substring(9) == "#";
                rules[pattern] = hasPlant;
            }

            var start = -2;

            for (var i = 0; i < 20; i++)
            {
                var sb = new StringBuilder();
                for (var j = 2; j < state.Length - 2; j++)
                {
                    var plant = state.Substring(j - 2, 5);
                    if (rules.ContainsKey(plant) && rules[plant])
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }

                state = sb.ToString();

                var dotsAtStart = state
                    .TakeWhile((x, a) => x == '.')
                    .Count();
                var dotsAtEnd = state
                    .Substring(state.Length - 4)
                    .Reverse()
                    .TakeWhile((x, a) => x == '.' && a < 4)
                    .Count();

                start += dotsAtStart - 2;
                if (dotsAtStart < 4)
                {
                    var prefix = string.Join("", Enumerable.Range(0, 4 - dotsAtStart).Select(x => '.'));
                    state = $"{prefix}{state}";
                }
                else
                {
                    state = state.Substring(dotsAtStart - 4);
                }
                var suffix = string.Join("", Enumerable.Range(0, 4 - dotsAtEnd).Select(x => '.'));

                state = $"{state}{suffix}";
            }

            var sum = 0;

            for (var i = 0; i < state.Length - 2; i++)
            {
                if (state[i + 2] == '#')
                {
                    sum += start + i;
                }
            }

            return sum;
        }
        public long PuzzleTwo(string input)
        {
            var lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var initialState = lines[0].Substring("initial state: ".Length);
            var state = $"....{initialState}....";

            var rules = new Dictionary<string, bool>();
            foreach (var line in lines.Skip(1))
            {
                var pattern = line.Substring(0, 5);
                var hasPlant = line.Substring(9) == "#";
                rules[pattern] = hasPlant;
            }

            var start = -2L;
            var oldState = "";
            var iterations = 0;

            while (oldState != state)
            {
                oldState = state;
                var sb = new StringBuilder();
                for (var j = 2; j < state.Length - 2; j++)
                {
                    var plant = state.Substring(j - 2, 5);
                    if (rules.ContainsKey(plant) && rules[plant])
                    {
                        sb.Append("#");
                    }
                    else
                    {
                        sb.Append(".");
                    }
                }

                state = sb.ToString();

                var dotsAtStart = state
                    .TakeWhile((x, a) => x == '.')
                    .Count();
                var dotsAtEnd = state
                    .Substring(state.Length - 4)
                    .Reverse()
                    .TakeWhile((x, a) => x == '.' && a < 4)
                    .Count();

                start += dotsAtStart - 2;
                if (dotsAtStart < 4)
                {
                    var prefix = string.Join("", Enumerable.Range(0, 4 - dotsAtStart).Select(x => '.'));
                    state = $"{prefix}{state}";
                }
                else
                {
                    state = state.Substring(dotsAtStart - 4);
                }
                var suffix = string.Join("", Enumerable.Range(0, 4 - dotsAtEnd).Select(x => '.'));

                state = $"{state}{suffix}";
                iterations++;
            }

            var sum = 0L;
            var targetIteration = 50000000000;
            start = start - iterations + targetIteration;

            for (var i = 0; i < state.Length - 2; i++)
            {
                if (state[i + 2] == '#')
                {
                    sum += start + i;
                }
            }

            return sum;
        }
    }
}