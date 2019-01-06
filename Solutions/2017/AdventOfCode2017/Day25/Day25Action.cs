namespace AdventOfCode2017.Day25
{
    public class Day25Action
    {
        public int Value { get; }

        public bool IsRight { get; }

        public char NextState { get; }

        public Day25Action(int value, bool isRight, char nextState)
        {
            this.Value = value;
            this.IsRight = isRight;
            this.NextState = nextState;
        }
    }
}