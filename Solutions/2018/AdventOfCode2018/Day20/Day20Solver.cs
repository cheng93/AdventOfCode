namespace AdventOfCode2018.Day20
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day20Solver
    {
        public int PuzzleOne(string input)
        {
            var depths = new List<List<int>>();
            depths.Add(new List<int>(new[] { 0 }));

            var depth = 0;
            var sum = 0;

            var directions = new[] { 'N', 'E', 'S', 'W' };
            foreach (var letter in input.Substring(1, input.Length - 2))
            {
                if (letter == '(')
                {
                    depths[depth][depths[depth].Count - 1] += sum;
                    depth++;
                    depths.Add(new List<int>());
                }
                if (letter == ')' || letter == '|')
                {
                    depths[depth][depths[depth].Count - 1] += sum;
                }
                if (letter == '(' || letter == '|')
                {
                    sum = 0;
                    depths[depth].Add(0);
                }
                if (letter == ')')
                {
                    var depthValue = depths[depth].Contains(0)
                        ? 0
                        : depths[depth].Max();

                    depths[depth - 1][depths[depth - 1].Count - 1] += depthValue;

                    depths.RemoveAt(depth);
                    depth--;

                    sum = 0;
                }

                if (directions.Contains(letter))
                {
                    sum++;
                }
            }

            return depths[0][0];
        }
        public int PuzzleTwo(string input, int doorsToPass)
        {
            var depths = new List<int>();
            var pointDepths = new List<Point>();
            var point = new Point(0, 0);
            var visited = new HashSet<Point>(new[] { point });

            var depth = 0;
            var sum = 0;

            var rooms = 0;

            var directions = new[] { 'N', 'E', 'S', 'W' };
            foreach (var letter in input.Substring(1, input.Length - 2))
            {
                if (letter == '(')
                {
                    pointDepths.Add(point);
                    depths.Add(sum);
                    depth++;
                }
                if (letter == '(' || letter == '|' | letter == ')')
                {
                    point = pointDepths[depth - 1];
                    sum = depths[depth - 1];
                }
                if (letter == ')')
                {
                    depth--;
                    depths.RemoveAt(depth);
                    pointDepths.RemoveAt(depth);
                }

                if (directions.Contains(letter))
                {
                    Size size;
                    switch (letter)
                    {
                        case 'N':
                            size = new Size(0, -1);
                            break;
                        case 'E':
                            size = new Size(1, 0);
                            break;
                        case 'S':
                            size = new Size(0, 1);
                            break;
                        case 'W':
                            size = new Size(-1, 0);
                            break;
                    }

                    point = Point.Add(point, size);
                    sum++;
                    if (sum >= doorsToPass && !visited.Contains(point))
                    {
                        rooms++;
                    }
                    visited.Add(point);
                }
            }

            return rooms;
        }
    }
}