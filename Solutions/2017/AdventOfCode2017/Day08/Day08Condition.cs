namespace AdventOfCode2017.Day08
{
    using System;
    using System.Collections.Generic;

    public class Day08Condition
    {
        public string Register { get; }

        public Func<int, bool> Operator { get; }

        public Day08Condition(string input)
        {
            // Example input: c == 10
            var splits = input.Split(' ');

            this.Register = splits[0];
            this.Operator = (x) => Operations[splits[1]](x, int.Parse(splits[2]));
        }

        private static Dictionary<string, Func<int, int, bool>> Operations
            = new Dictionary<string, Func<int, int, bool>>
            {
                {">", (x, y) => x > y},
                {">=", (x, y) => x >= y},
                {"<", (x, y) => x < y},
                {"<=", (x, y) => x <= y},
                {"==", (x, y) => x == y},
                {"!=", (x, y) => x != y},
            };
    }
}