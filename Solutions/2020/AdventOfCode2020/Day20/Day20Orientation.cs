using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day20
{
    public class Day20Orientation
    {
        public Day20Orientation(Dictionary<char, string> sides)
        {
            this.North = sides['n'];
            this.East = sides['e'];
            this.South = sides['s'];
            this.West = sides['w'];
        }

        public string North { get; }
        public string East { get; }
        public string South { get; }
        public string West { get; }

        public Day20Orientation Flip()
        {
            var dict = new Dictionary<char, string>();
            dict['n'] = this.South;
            dict['e'] = new string(this.East.Reverse().ToArray());
            dict['s'] = this.North;
            dict['w'] = new string(this.West.Reverse().ToArray());

            return new Day20Orientation(dict);
        }

        public Day20Orientation Rotate()
        {
            var dict = new Dictionary<char, string>();
            dict['n'] = new string(this.West.Reverse().ToArray());
            dict['e'] = this.North;
            dict['s'] = new string(this.East.Reverse().ToArray());
            dict['w'] = this.South;

            return new Day20Orientation(dict);
        }
    }
}