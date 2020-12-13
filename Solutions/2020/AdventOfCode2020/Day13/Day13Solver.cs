using System;
using System.Linq;

namespace AdventOfCode2020.Day13
{
    public class Day13Solver
    {
        public int PuzzleOne(string input, int earliest = 1002561)
        {
            var buses = input
                .Split(',')
                .Where(x => x != "x")
                .Select(int.Parse)
                .ToArray();

            var min = int.MaxValue;
            var busId = 0;

            foreach (var bus in buses)
            {
                var quotient = earliest / bus;
                if (earliest % bus == 0)
                {
                    return 0;
                }
                var next = (quotient * bus) + bus;
                if (next < min)
                {
                    min = next;
                    busId = bus;
                }
            }

            return (min - earliest) * busId;
        }

        public long PuzzleTwo(string input)
        {
            var buses = input
                .Split(',')
                .ToArray();

            var lcm = long.Parse(buses[0]);
            var offset = 0L;
            for (var i = 1; i < buses.Length; i++)
            {
                if (buses[i] == "x")
                {
                    continue;
                }
                var bus = int.Parse(buses[i]);
                var timestamp = 0L;
                do
                {
                    timestamp += lcm;
                }
                while ((timestamp + offset + i) % bus != 0);
                offset = timestamp + offset;
                lcm = Lcm(lcm, bus);
            }

            long Gcd(long x, long y)
            {
                while (y != 0)
                {
                    var t = y;
                    y = x % y;
                    x = t;
                }

                return Math.Abs(x);
            }

            long Lcm(long x, long y)
            {
                return Math.Abs(x * y) / Gcd(x, y);
            }

            return offset;
        }
    }
}