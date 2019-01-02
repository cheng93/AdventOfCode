namespace AdventOfCode2018.Day15
{
    using System.Drawing;

    public class Day15Unit
    {
        public Point Position { get; set; }

        public char Icon { get; set; }

        public int HitPoints { get; set; } = 200;

        public int AttackPower { get; set; } = 3;

        public Day15Unit(Point position, char icon)
        {
            Position = position;
            Icon = icon;
        }
    }
}