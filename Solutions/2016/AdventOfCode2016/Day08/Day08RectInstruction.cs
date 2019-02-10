namespace AdventOfCode2016.Day08
{
    using System.Collections.Generic;
    using System.Drawing;

    public class Day08RectInstruction : IDay08Instruction
    {
        private readonly int wide;
        private readonly int tall;

        public Day08RectInstruction(int wide, int tall)
        {
            this.wide = wide;
            this.tall = tall;
        }

        public void Apply(IDictionary<Point, bool> screen)
        {
            for (var i = 0; i < this.wide; i++)
            {
                for (var j = 0; j < this.tall; j++)
                {
                    screen[new Point(i, j)] = true;
                }
            }
        }
    }
}