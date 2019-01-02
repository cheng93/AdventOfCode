namespace AdventOfCode2018.Day17
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class Day17Scan
    {
        public ICollection<Point> Points { get; } = new List<Point>();
        public Day17Scan(string input)
        {
            // Example input: x=495, y=2..7
            var splits = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            var root = splits[0].Split('=');
            var rootIsX = root[0] == "x";
            var rootValue = int.Parse(root[1]);

            var range = splits[1]
                .Substring(2)
                .Split(new[] { ".." }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (var i = range[0]; i <= range[1]; i++)
            {
                var point = rootIsX ? new Point(rootValue, i) : new Point(i, rootValue);
                this.Points.Add(point);
            }
        }
    }
}