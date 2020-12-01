using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day01
{
    public class Day01Solver
    {
        public int PuzzleOne(IEnumerable<int> input)
        {
            var dict = new Dictionary<int, int>();

            foreach (var value in input)
            {
                if (dict.TryGetValue(value, out var pair))
                {
                    return value * pair;
                }

                dict[2020 - value] = value;
            }

            throw new System.Exception();
        }
        public long PuzzleTwo(IEnumerable<int> input)
        {
            var dict = new Dictionary<int, List<int>>();

            foreach (var value in input)
            {
                if (dict.TryGetValue(value, out var list) && list.Count == 2)
                {
                    return value * list[0] * list[1];
                }

                foreach (var key in dict.Keys.ToList())
                {
                    var newValue = key - value;
                    if (newValue > 0)
                    {
                        var newList = new List<int> { dict[key][0], value };
                        dict[newValue] = newList;
                    }
                }

                dict[2020 - value] = new List<int> { value };
            }

            throw new System.Exception();
        }
    }
}