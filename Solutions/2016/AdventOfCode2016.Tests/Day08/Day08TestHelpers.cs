namespace AdventOfCode2016.Tests.Day08
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public static class Day08TestHelpers
    {
        public static IDictionary<Point, bool> ToDictionary(this string input)
        {
            var dictionary = new Dictionary<Point, bool>();

            var rows = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (var j = 0; j < rows.Length; j++)
            {
                var row = rows[j];
                for (var i = 0; i < row.Length; i++)
                {
                    var point = new Point(i, j);
                    dictionary.Add(point, row[i] == '#');
                }
            }

            return dictionary;
        }
    }
}