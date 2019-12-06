using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day06
{
    public class Day06Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var orbits = input.Select(x => new Day06Orbit(x));

            var counts = orbits
                .Select(x => x.OrbitBy)
                .Distinct()
                .ToDictionary(x => x, x => 0);
            counts["COM"] = 0;
            var tree = orbits
                .GroupBy(x => x.Orbitted)
                .ToDictionary(x => x.Key, x => x.Select(o => o.OrbitBy));

            foreach (var orbit in orbits)
            {
                Traverse(orbit.OrbitBy);
            }

            void Traverse(string node)
            {
                counts[node]++;
                if (tree.ContainsKey(node))
                {
                    foreach (var child in tree[node])
                    {
                        Traverse(child);
                    }
                }
            }

            return counts.Values.Sum();
        }


        public int PuzzleTwo(IEnumerable<string> input)
        {
            var orbits = input.Select(x => new Day06Orbit(x));

            var parents = orbits
                .ToDictionary(x => x.OrbitBy, x => x.Orbitted);

            var youPath = PathToCom("YOU");
            var sanPath = PathToCom("SAN");

            HashSet<string> PathToCom(string node)
            {
                var set = new HashSet<string>();
                while (node != "COM")
                {
                    node = parents[node];
                    set.Add(node);
                }
                return set;
            }

            youPath.SymmetricExceptWith(sanPath);
            return youPath.Count();
        }
    }
}