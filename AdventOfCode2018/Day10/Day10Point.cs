namespace AdventOfCode2018.Day10
{
    using System.Drawing;
    using System.Linq;

    public class Day10Point
    {
        public Point Position { get; }

        public Point Velocity { get; }

        public Day10Point(string input)
        {
            // Example input: position=< 9,  1> velocity=< 0,  2>
            var velocityPosition = input.IndexOf(" velocity=");
            var positionLength = "position=".Length;
            var velocityLength = " velocity=".Length;

            var position = ParseInput(input.Substring(positionLength, velocityPosition - positionLength));
            var velocity = ParseInput(input.Substring(velocityPosition + velocityLength));

            this.Position = new Point(position[0], position[1]);
            this.Velocity = new Point(velocity[0], velocity[1]);
        }

        private Day10Point(Point position, Point velocity)
        {
            this.Position = position;
            this.Velocity = velocity;
        }

        public Point Move(int iterations)
            => Point.Add(this.Position, new Size(this.Velocity.X * iterations, this.Velocity.Y * iterations));

        private static int[] ParseInput(string input)
        {
            return input
                .Substring(1, input.Length - 2)
                .Split(',')
                .Select(x => int.Parse(x.Trim()))
                .ToArray();
        }
    }
}