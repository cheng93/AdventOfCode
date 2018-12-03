
namespace AdventOfCode2018.Day03
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day03Solver
    {
        public int PuzzleOne(IEnumerable<string> input)
        {
            var claims = input.Select(x => new Day03Claim(x));
            var areas = new HashSet<Point>();
            var overlap = new HashSet<Point>();

            foreach (var claim in claims)
            {
                for (var i = 0; i < claim.Width; i++)
                {
                    for (var j = 0; j < claim.Height; j++)
                    {
                        var point = new Point(claim.Left + i, claim.Top + j);

                        if (areas.Contains(point))
                        {
                            overlap.Add(point);
                        }
                        else
                        {
                            areas.Add(point);
                        }
                    }
                }
            }

            return overlap.Count;
        }
        public int PuzzleTwo(IEnumerable<string> input)
        {
            var claims = input.Select(x => new Day03Claim(x));
            var areas = new Dictionary<Point, List<int>>();
            var blacklist = new HashSet<int>();
            var potential = new HashSet<int>();

            foreach (var claim in claims)
            {
                for (var i = 0; i < claim.Width; i++)
                {
                    for (var j = 0; j < claim.Height; j++)
                    {
                        var point = new Point(claim.Left + i, claim.Top + j);

                        if (areas.ContainsKey(point))
                        {
                            areas[point].Add(claim.Id);
                            var ids = areas[point];
                            foreach (var id in ids)
                            {
                                if (!blacklist.Contains(id))
                                {
                                    blacklist.Add(id);
                                }
                                potential.Remove(id);
                            }
                        }
                        else
                        {
                            if (!blacklist.Contains(claim.Id))
                            {
                                potential.Add(claim.Id);
                            }
                            areas.Add(point, new List<int>() { claim.Id });
                        }
                    }
                }
            }

            return potential.First();
        }
    }
}