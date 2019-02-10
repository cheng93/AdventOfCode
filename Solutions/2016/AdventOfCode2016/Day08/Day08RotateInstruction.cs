namespace AdventOfCode2016.Day08
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public abstract class Day08RotateInstruction : IDay08Instruction
    {
        private readonly int index;
        private readonly int pixels;

        public Day08RotateInstruction(int index, int pixels)
        {
            this.index = index;
            this.pixels = pixels;
        }

        public void Apply(IDictionary<Point, bool> screen)
        {
            var length = this.GetLength(screen.Keys);

            var original = Enumerable.Range(0, length)
                .Select(x => screen[this.GetPoint(this.index, x)])
                .ToArray();

            for (var i = 0; i < length; i++)
            {
                screen[this.GetPoint(this.index, (i + this.pixels) % length)] = original[i];
            }
        }

        protected abstract int GetLength(IEnumerable<Point> points);

        protected abstract Point GetPoint(int index, int counter);
    }

    public class Day08ColumnRotateInstruction : Day08RotateInstruction
    {
        public Day08ColumnRotateInstruction(int index, int pixels)
            : base(index, pixels)
        {
        }

        protected override int GetLength(IEnumerable<Point> points)
            => points.Select(x => x.Y).Max() + 1;

        protected override Point GetPoint(int index, int counter)
            => new Point(index, counter);
    }

    public class Day08RowRotateInstruction : Day08RotateInstruction
    {
        public Day08RowRotateInstruction(int index, int pixels)
            : base(index, pixels)
        {
        }

        protected override int GetLength(IEnumerable<Point> points)
            => points.Select(x => x.X).Max() + 1;

        protected override Point GetPoint(int index, int counter)
            => new Point(counter, index);
    }
}