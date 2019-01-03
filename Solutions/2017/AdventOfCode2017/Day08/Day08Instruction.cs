namespace AdventOfCode2017.Day08
{
    using System;

    public class Day08Instruction
    {
        public string Register { get; }

        public int Change { get; }

        public Day08Condition Condition { get; }

        public Day08Instruction(string input)
        {
            // Example input: c inc -20 if c == 10
            var splits = input.Split(new[] { " if " }, StringSplitOptions.RemoveEmptyEntries);

            var firsts = splits[0].Split(' ');

            this.Register = firsts[0];

            this.Change = (firsts[1] == "inc" ? 1 : -1) * int.Parse(firsts[2]);

            this.Condition = new Day08Condition(splits[1]);
        }
    }
}