namespace AdventOfCode2017.Day24
{
    using System.Linq;

    public class Day24Component
    {
        public string Id { get; }

        public int PinA { get; }

        public int PinB { get; }

        public Day24Component(string input)
        {
            // Example input: 9/10

            var splits = input.Split('/').Select(int.Parse).ToArray();
            this.Id = input;
            this.PinA = splits[0];
            this.PinB = splits[1];
        }
    }
}