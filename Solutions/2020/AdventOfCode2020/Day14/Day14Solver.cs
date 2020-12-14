using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day14
{
    public class Day14Solver
    {
        public long PuzzleOne(IEnumerable<string> input)
        {
            var memory = new Dictionary<int, string>();

            string bitmask = null;
            foreach (var line in input)
            {
                var splits = line.Split(" = ");
                if (line.StartsWith("mask"))
                {
                    bitmask = splits[1];
                    continue;
                }

                var address = int.Parse(splits[0][4..^1]);
                var value = long.Parse(splits[1]);

                var binary = Convert.ToString(value, 2).PadLeft(36, '0').ToCharArray();

                for (var i = 0; i < binary.Length; i++)
                {
                    if (bitmask[i] == '0' || bitmask[i] == '1')
                    {
                        binary[i] = bitmask[i];
                    }
                }

                memory[address] = string.Join("", binary);
            }

            return memory.Values
                .Select(x => Convert.ToInt64(x, 2))
                .Sum();
        }

        public long PuzzleTwo(IEnumerable<string> input)
        {
            var memory = new Dictionary<long, long>();

            string bitmask = null;
            foreach (var line in input)
            {
                var splits = line.Split(" = ");
                if (line.StartsWith("mask"))
                {
                    bitmask = splits[1];
                    continue;
                }

                var address = int.Parse(splits[0][4..^1]);
                var value = long.Parse(splits[1]);

                var binary = Convert.ToString(address, 2).PadLeft(36, '0').ToCharArray();
                var addresses = new List<char[]>();

                for (var i = 0; i < binary.Length; i++)
                {
                    if (bitmask[i] == '1')
                    {
                        binary[i] = bitmask[i];
                    }
                }
                addresses.Add(binary);

                for (var i = 0; i < binary.Length; i++)
                {
                    if (bitmask[i] == 'X')
                    {
                        var copy = addresses.ToList();
                        foreach (var a in addresses)
                        {
                            a[i] = '0';
                            var copyA = a.ToArray();
                            copyA[i] = '1';
                            copy.Add(copyA);
                        }
                        addresses = copy;
                    }
                }

                foreach (var a in addresses)
                {
                    var id = Convert.ToInt64(string.Join("", a), 2);
                    memory[id] = value;
                }
            }

            return memory.Values.Sum();
        }
    }
}