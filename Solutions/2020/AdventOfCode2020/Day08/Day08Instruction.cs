using System.Collections.Generic;

namespace AdventOfCode2020.Day08
{
    public class Day08Instruction
    {
        // Input: acc -99
        public Day08Instruction(string input)
        {
            var splits = input.Split(" ");
            this.Operation = splits[0];
            this.Argument = int.Parse(splits[1]);
        }

        public string Operation { get; }
        public int Argument { get; }
    }
}