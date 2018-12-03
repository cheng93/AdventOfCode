namespace AdventOfCode2018.Day03
{
    using System.Linq;

    public class Day03Claim
    {
        public int Id { get; set; }

        public int Left { get; set; }

        public int Top { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public Day03Claim(string input)
        {
            // Example input: #1 @ 1,3: 4x4
            var splits = input.Split(' ');

            this.Id = int.Parse(splits[0].Substring(1));

            var position = splits[2]
                .Substring(0, splits[2].Length - 1)
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            this.Left = position[0];
            this.Top = position[1];

            var dimensions = splits[3]
                .Split('x')
                .Select(int.Parse)
                .ToArray();

            this.Width = dimensions[0];
            this.Height = dimensions[1];
        }
    }
}