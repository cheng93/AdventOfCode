namespace AdventOfCode2019.Day12
{
    public class Day12Axis
    {
        public int Position { get; }
        public int Velocity { get; }

        public Day12Axis(int position, int velocity)
        {
            this.Velocity = velocity;
            this.Position = position;
        }

        public override bool Equals(object obj)
        {
            var cast = obj as Day12Axis;
            if (cast == null || GetType() != obj.GetType()) return false;
            return (this.Position, this.Velocity) == (cast.Position, cast.Velocity);
        }

        public override int GetHashCode()
        {
            return (this.Position, this.Velocity).GetHashCode();
        }
    }
}