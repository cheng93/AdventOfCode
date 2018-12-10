namespace AdventOfCode2018.Day10
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class Day10Output
    {
        public string Draw(IEnumerable<Point> points)
        {
            var minX = int.MaxValue;
            var minY = int.MaxValue;
            var maxX = int.MinValue;
            var maxY = int.MinValue;

            foreach (var point in points)
            {
                if (point.X > maxX) maxX = point.X;
                if (point.X < minX) minX = point.X;
                if (point.Y > maxY) maxY = point.Y;
                if (point.Y < minY) minY = point.Y;
            }

            var dict = points
                .OrderBy(x => x.Y)
                .ThenBy(x => x.X)
                .GroupBy(x => x.Y)
                .ToDictionary(x => x.Key, x => new HashSet<int>(x.Select(y => y.X)));

            var stringBuilder = new StringBuilder();

            for (var i = minY; i <= maxY; i++)
            {
                for (var j = minX; j <= maxX; j++)
                {
                    if (dict.ContainsKey(i) && dict[i].Contains(j))
                    {
                        stringBuilder.Append("#");
                    }
                    else
                    {
                        stringBuilder.Append(".");
                    }
                }
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}