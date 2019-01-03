namespace AdventOfCode2017.Day07
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day07Solver
    {
        public string PuzzleOne(string input)
        {
            var programs = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day07Program(x));

            var names = new HashSet<string>();
            var nonBottom = new HashSet<string>();

            foreach (var program in programs)
            {
                if (!nonBottom.Contains(program.Name))
                {
                    names.Add(program.Name);
                }

                foreach (var subProgram in program.SubPrograms)
                {
                    nonBottom.Add(subProgram);
                    names.Remove(subProgram);
                }
            }

            return names.First();
        }

        public int PuzzleTwo(string input)
        {
            var programs = input
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day07Program(x))
                .ToDictionary(x => x.Name, x => x);


            var names = new HashSet<string>();
            var nonBottom = new HashSet<string>();

            foreach (var program in programs.Values)
            {
                if (!nonBottom.Contains(program.Name))
                {
                    names.Add(program.Name);
                }

                foreach (var subProgram in program.SubPrograms)
                {
                    nonBottom.Add(subProgram);
                    names.Remove(subProgram);
                }
            }

            var root = names.First();

            var weights = new Dictionary<string, int>();

            weights[root] = GetWeight(root, programs, weights);

            var queue = new Queue<string>();
            queue.Enqueue(root);
            var unequalPrograms = new List<string>();
            string badNode = null;

            while (queue.Any())
            {
                var node = queue.Dequeue();
                var program = programs[node];

                if (program.SubPrograms.Select(x => weights[x]).Distinct().Count() != 1)
                {
                    foreach (var subProgram in program.SubPrograms)
                    {
                        queue.Enqueue(subProgram);
                    }
                    unequalPrograms = program.SubPrograms.ToList();

                    if (programs[root].SubPrograms.Contains(node))
                    {
                        badNode = node;
                    }
                }
            }

            if (badNode == null)
            {
                var group = unequalPrograms.GroupBy(x => weights[x], x => x);
                var single = group.Where(x => x.Count() == 1).First();
                var other = group.Where(x => x.Key != single.Key).First();

                return programs[single.Single()].Weight + other.Key - single.Key;
            }

            var badWeight = weights[badNode];
            var goodWeight = weights[programs[root].SubPrograms.Where(x => x != badNode).First()];
            var diff = goodWeight - badWeight;
            if (unequalPrograms.Count == 2)
            {
                var dict = unequalPrograms.ToDictionary(x => x, x => weights[x]);
                var value = diff > 0 ? dict.Values.Min() : dict.Values.Max();
                var node = dict.Where(x => x.Value == value).First().Key;
                return programs[node].Weight + diff;

            }
            else
            {
                var group = unequalPrograms.GroupBy(x => weights[x], x => x);
                var single = group.Where(x => x.Count() == 1).First();

                return programs[single.Single()].Weight + diff;
            }
        }

        private static int GetWeight(string name, Dictionary<string, Day07Program> dict, Dictionary<string, int> weights)
        {
            if (weights.ContainsKey(name))
            {
                return weights[name];
            }

            var program = dict[name];
            var sum = 0;

            foreach (var subProgram in program.SubPrograms)
            {
                if (!weights.ContainsKey(subProgram))
                {
                    weights[subProgram] = GetWeight(subProgram, dict, weights);
                }
                sum += weights[subProgram];
            }

            return program.Weight + sum;
        }
    }
}