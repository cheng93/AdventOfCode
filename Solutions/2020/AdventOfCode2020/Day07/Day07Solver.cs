using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day07
{
    public class Day07Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var lookup = new Dictionary<string, HashSet<string>>();
            foreach (var line in input)
            {
                var bag = new Day07Bag(line);
                foreach (var otherBag in bag.Contains)
                {
                    if (lookup.TryGetValue(otherBag.Name, out var hashSet))
                    {
                        hashSet.Add(bag.Name);
                    }
                    else
                    {
                        lookup[otherBag.Name] = new HashSet<string>() { bag.Name };
                    }
                }
            }

            var visited = new HashSet<string>();

            void DFS(string name)
            {
                visited.Add(name);
                if (lookup.TryGetValue(name, out var otherBags))
                {
                    foreach (var otherBag in otherBags)
                    {
                        if (!visited.Contains(otherBag))
                        {
                            DFS(otherBag);
                        }
                    }
                }
            }

            DFS("shiny gold");

            return visited.Count - 1;
        }

        public int PuzzleTwo(IEnumerable<string> input)
        {
            var lookup = new Dictionary<string, Day07Bag>();
            foreach (var line in input)
            {
                var bag = new Day07Bag(line);
                lookup[bag.Name] = bag;
            }

            int Recurse(string name)
            {
                var bag = lookup[name];
                return 1 + bag.Contains.Sum(x => x.Amount * Recurse(x.Name));
            }

            return Recurse("shiny gold") - 1;
        }
    }
}