namespace AdventOfCode2017.Day13
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day13Solver
    {
        public int PuzzleOne(string input)
        {
            var layers = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day13Layer(x));

            var caught = new HashSet<Day13Layer>();

            foreach (var layer in layers)
            {
                var length = Math.Max(1, (layer.Range - 1) * 2);
                if (layer.Depth % length == 0)
                {
                    caught.Add(layer);
                }
            }

            return caught.Sum(x => x.Depth * x.Range);
        }

        public int PuzzleTwo(string input)
        {
            var layers = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day13Layer(x));

            var delay = 0;

            while (true)
            {
                var caught = false;

                foreach (var layer in layers)
                {
                    var length = Math.Max(1, (layer.Range - 1) * 2);
                    if ((layer.Depth + delay) % length == 0)
                    {
                        caught = true;
                        break;
                    }
                }

                if (!caught)
                {
                    break;
                }
                delay++;
            }

            return delay;
        }
    }
}