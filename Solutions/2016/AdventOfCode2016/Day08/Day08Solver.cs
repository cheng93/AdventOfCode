namespace AdventOfCode2016.Day08
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class Day08Solver
    {
        public int PuzzleOne(string input) => Solve(input).Count;

        public string PuzzleTwo(string input) => Solve(input).Code;

        private static (int Count, string Code) Solve(string input)
        {
            var instructions = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new Day08InstructionFactory().Create(x));

            var screen = new Dictionary<Point, bool>();

            for (var i = 0; i < 50; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    screen.Add(new Point(i, j), false);
                }
            }

            foreach (var instruction in instructions)
            {
                instruction.Apply(screen);
            }

            var sb = new StringBuilder();

            for (var j = 0; j < 6; j++)
            {
                for (var i = 0; i < 50; i++)
                {
                    sb.Append(screen[new Point(i, j)] ? '#' : '.');
                }
                sb.AppendLine();
            }


            return (screen.Values.Count(x => x), sb.ToString());
        }
    }
}