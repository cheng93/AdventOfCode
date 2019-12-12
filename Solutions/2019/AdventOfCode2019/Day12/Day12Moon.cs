using System;

namespace AdventOfCode2019.Day12
{
    public class Day12Moon
    {
        public Day12Moon(string input)
        {
            this.Position = new Day12Point(input);
            this.Velocity = new Day12Point();
        }

        public Day12Point Position { get; }
        public Day12Point Velocity { get; }

        public Day12Axis GetAxis(Func<Day12Point, int> selector)
        {
            return new Day12Axis(selector(this.Position), selector(this.Velocity));
        }
    }
}