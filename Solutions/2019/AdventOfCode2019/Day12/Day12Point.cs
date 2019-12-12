using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day12
{
    public class Day12Point
    {
        public Day12Point() { }

        public Day12Point(string input)
        {
            // Example input: <x=-8, y=-10, z=0>
            var parameters = input.Split(',')
                .Select(x => x.Split('=')[1].Replace(">", string.Empty))
                .Select(int.Parse)
                .ToArray();

            this.X = parameters[0];
            this.Y = parameters[1];
            this.Z = parameters[2];
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public IEnumerable<int> ToEnumerable()
        {
            yield return X;
            yield return Y;
            yield return Z;
        }
    }
}