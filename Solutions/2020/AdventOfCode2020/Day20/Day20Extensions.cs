using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day20
{
    public static class Day20Extensions
    {
        public static Dictionary<(int X, int Y), char> Rotate(this Dictionary<(int X, int Y), char> dict)
        {
            var newDict = new Dictionary<(int X, int Y), char>();
            var max = dict.Keys.Select(x => x.X).Max();

            foreach (var kvp in dict)
            {
                var x = max - kvp.Key.Y;
                var y = kvp.Key.X;
                newDict[(x, y)] = kvp.Value;
            }
            return newDict;
        }

        public static Dictionary<(int X, int Y), char> Flip(this Dictionary<(int X, int Y), char> dict)
        {
            var newDict = new Dictionary<(int X, int Y), char>();
            var max = dict.Keys.Select(x => x.Y).Max();

            foreach (var kvp in dict)
            {
                var x = kvp.Key.X;
                var y = max - kvp.Key.Y;
                newDict[(x, y)] = kvp.Value;
            }
            return newDict;
        }

        public static void Add(this Dictionary<(int X, int Y), char> dict, Dictionary<(int X, int Y), char> add)
        {
            foreach (var kvp in add)
            {
                dict.Add(kvp.Key, kvp.Value);
            }
        }
    }
}