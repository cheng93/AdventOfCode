namespace AdventOfCode2018.Day23
{
    using System;
    using System.Linq;

    public class Day23Nanobot
    {
        public (int X, int Y, int Z) Position { get; }

        public int Radius { get; }

        public Day23Nanobot(string input)
        {
            // Example input: pos=<0,0,0>, r=4
            var splits = input.Split(new[] { ", ", }, StringSplitOptions.RemoveEmptyEntries);

            var positions = splits[0]
                .Substring(5, splits[0].Length - 6)
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            this.Position = (positions[0], positions[1], positions[2]);

            this.Radius = int.Parse(splits[1].Substring(2));
        }

        public Day23Nanobot((int X, int Y, int Z) position, int radius)
        {
            this.Position = position;
            this.Radius = radius;
        }
    }
}