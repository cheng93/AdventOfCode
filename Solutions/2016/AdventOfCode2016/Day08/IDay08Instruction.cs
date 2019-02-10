namespace AdventOfCode2016.Day08
{
    using System.Collections.Generic;
    using System.Drawing;

    public interface IDay08Instruction
    {
        void Apply(IDictionary<Point, bool> screen);
    }
}