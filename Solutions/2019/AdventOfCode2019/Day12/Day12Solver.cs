using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day12
{
    public class Day12Solver
    {
        public int PuzzleOne(IEnumerable<string> input, int steps = 1000)
        {
            var moons = input.Select(x => new Day12Moon(x)).ToArray();
            for (var i = 0; i < steps; i++)
            {
                for (var j = 0; j < moons.Length; j++)
                {
                    var moon = moons[j];
                    moon.Velocity.X += CalcVelocity(moons, j, x => x.X);
                    moon.Velocity.Y += CalcVelocity(moons, j, x => x.Y);
                    moon.Velocity.Z += CalcVelocity(moons, j, x => x.Z);
                }
                for (var j = 0; j < moons.Length; j++)
                {
                    var moon = moons[j];
                    moon.Position.X += moon.Velocity.X;
                    moon.Position.Y += moon.Velocity.Y;
                    moon.Position.Z += moon.Velocity.Z;
                }
            }

            return moons
                .Select(x =>
                {
                    var pot = x.Position.ToEnumerable().Select(x => Math.Abs(x)).Sum();
                    var kin = x.Velocity.ToEnumerable().Select(x => Math.Abs(x)).Sum();
                    return pot * kin;
                })
                .Sum();
        }

        public long PuzzleTwo(IEnumerable<string> input)
        {
            var moons = input.Select(x => new Day12Moon(x)).ToArray();
            var states = new[]
            {
                new Dictionary<(Day12Axis a, Day12Axis b, Day12Axis c, Day12Axis d), int>(),
                new Dictionary<(Day12Axis a, Day12Axis b, Day12Axis c, Day12Axis d), int>(),
                new Dictionary<(Day12Axis a, Day12Axis b, Day12Axis c, Day12Axis d), int>()
            };

            var axes = new long?[] { null, null, null };

            var selector = new Func<Day12Point, int>[]
            {
                p => p.X,
                p => p.Y,
                p => p.Z
            };

            var iteration = 0;
            var offset = int.MaxValue;
            while (axes.Any(x => !x.HasValue))
            {
                for (var j = 0; j < 3; j++)
                {
                    var a = moons[0].GetAxis(selector[j]);
                    var b = moons[1].GetAxis(selector[j]);
                    var c = moons[2].GetAxis(selector[j]);
                    var d = moons[3].GetAxis(selector[j]);
                    var current = (a, b, c, d);
                    if (!axes[j].HasValue)
                    {
                        if (states[j].ContainsKey(current))
                        {
                            axes[j] = iteration - states[j][current];
                            offset = Math.Min(offset, states[j][current]);
                        }
                        states[j][current] = iteration;
                    }
                }
                for (var j = 0; j < moons.Length; j++)
                {
                    var moon = moons[j];
                    moon.Velocity.X += CalcVelocity(moons, j, x => x.X);
                    moon.Velocity.Y += CalcVelocity(moons, j, x => x.Y);
                    moon.Velocity.Z += CalcVelocity(moons, j, x => x.Z);
                }
                for (var j = 0; j < moons.Length; j++)
                {
                    var moon = moons[j];
                    moon.Position.X += moon.Velocity.X;
                    moon.Position.Y += moon.Velocity.Y;
                    moon.Position.Z += moon.Velocity.Z;
                }
                iteration++;
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

            return Lcm(Lcm(axes[0].Value, axes[1].Value), axes[2].Value) + offset;
        }

        private static int CalcVelocity(Day12Moon[] moons, int index, Func<Day12Point, int> selector)
        {
            var moon = moons[index];
            return moons
                .Where((x, k) => k != index)
                .Select(x => selector(moon.Position) < selector(x.Position)
                    ? 1
                    : selector(moon.Position) > selector(x.Position)
                        ? -1
                        : 0)
                .Sum();
        }
    }
}