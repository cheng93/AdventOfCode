using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day20
{
    public class Day20SeaMonster
    {
        public HashSet<(int X, int Y)> Find((int X, int Y) coord)
        {
            var spaces = new (int X, int Y)[]
            {
                (18, 0),
                (0, 1),
                (5, 1),
                (6, 1),
                (11, 1),
                (12, 1),
                (17, 1),
                (18, 1),
                (19, 1),
                (1, 2),
                (4, 2),
                (7, 2),
                (10, 2),
                (13, 2),
                (16, 2)
            };

            var set = new HashSet<(int X, int Y)>();
            foreach (var space in spaces)
            {
                set.Add((coord.X + space.X, coord.Y + space.Y));
            }

            return set;
        }
    }
}