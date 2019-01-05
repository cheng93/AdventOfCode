namespace AdventOfCode2017.Day20
{
    using System;

    public class Day20Particle
    {
        public int Id { get; }
        public Day20Point Position { get; }

        public Day20Point Velocity { get; }

        public Day20Point Acceleration { get; }

        public Day20Particle(int id, string input)
        {
            this.Id = id;

            // Example input: p=<-878,1841,2096>, v=<-126,264,300>, a=<7,-18,-20>
            var splits = input.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            this.Position = new Day20Point(splits[0].Substring(3, splits[0].Length - 4));
            this.Velocity = new Day20Point(splits[1].Substring(3, splits[1].Length - 4));
            this.Acceleration = new Day20Point(splits[2].Substring(3, splits[2].Length - 4));
        }
    }
}