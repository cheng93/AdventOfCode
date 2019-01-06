namespace AdventOfCode2017.Day24
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day24Solver
    {
        public int PuzzleOne(string input) => Solve(input).Strongest;

        public int PuzzleTwo(string input) => Solve(input).LongestStrength;

        private static (int Strongest, int LongestStrength) Solve(string input)
        {
            var components = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day24Component(x))
                .ToDictionary(x => x.Id, x => x);

            var dict = components.Values
                .SelectMany(x => new (int Pin, string Id)[]
                {
                    (x.PinA, x.Id),
                    (x.PinB, x.Id)
                })
                .ToLookup(x => x.Pin, x => x.Id);

            var stack = new Stack<Day24Bridge>();

            var strength = int.MinValue;
            var longest = int.MinValue;
            var longestStrength = int.MinValue;

            stack.Push(Day24Bridge.Initial);

            while (stack.Any())
            {
                var bridge = stack.Pop();

                var bridgeStrength = bridge.Components.Sum(x => components[x].PinA + components[x].PinB);
                if (bridgeStrength > strength)
                {
                    strength = bridgeStrength;
                }

                if (bridge.Components.Count > longest)
                {
                    longest = bridge.Components.Count;
                    longestStrength = int.MinValue;
                }

                if (bridge.Components.Count == longest && bridgeStrength > longestStrength)
                {
                    longestStrength = bridgeStrength;
                }

                foreach (var component in dict[bridge.Pin])
                {
                    if (!bridge.Components.Contains(component))
                    {
                        stack.Push(bridge.Add(components[component]));
                    }
                }
            }

            return (strength, longestStrength);
        }
    }
}