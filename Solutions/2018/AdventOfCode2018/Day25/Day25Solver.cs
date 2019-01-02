namespace AdventOfCode2018.Day25
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Day25Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var points = input
                .Select(x =>
                {
                    var splits = x
                        .Split(',')
                        .Select(y => y.Trim())
                        .Select(int.Parse)
                        .ToArray();

                    return (A: splits[0], B: splits[1], C: splits[2], D: splits[3]);
                });

            var constellations = new List<HashSet<(int A, int B, int C, int D)>>();

            foreach (var point in points)
            {
                HashSet<(int A, int B, int C, int D)> pointConstellation = null;

                foreach (var constellation in constellations.ToList())
                {
                    foreach (var found in constellation.ToList())
                    {
                        if (ManhattanDistance(point, found) <= 3)
                        {
                            if (pointConstellation == null)
                            {
                                pointConstellation = constellation;
                                constellation.Add(point);
                            }
                            else
                            {
                                foreach (var old in constellation)
                                {
                                    pointConstellation.Add(old);
                                }

                                constellations.Remove(constellation);
                            }

                            break;
                        }
                    }
                }

                if (pointConstellation == null)
                {
                    constellations.Add(new HashSet<(int A, int B, int C, int D)>(new[] { point }));
                }
            }

            return constellations.Count;
        }

        private static int ManhattanDistance((int A, int B, int C, int D) a, (int A, int B, int C, int D) b)
            => Math.Abs(a.A - b.A) + Math.Abs(a.B - b.B) + Math.Abs(a.C - b.C) + Math.Abs(a.D - b.D);
    }
}