namespace AdventOfCode2018.Day13
{
    using System.Collections.Generic;
    using System.Drawing;

    public class Day13PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.Y.CompareTo(y.Y) != 0)
            {
                return x.Y.CompareTo(y.Y);
            }
            else
            {
                return x.X.CompareTo(y.X);
            }
        }
    }
}