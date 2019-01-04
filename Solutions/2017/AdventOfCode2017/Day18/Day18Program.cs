namespace AdventOfCode2017.Day18
{
    using System.Collections.Generic;

    public class Day18Program
    {
        public Dictionary<string, long> Registers { get; }

        public int Index { get; set; } = 0;

        public Queue<long> Queue { get; } = new Queue<long>();

        public bool Awaiting { get; set; } = false;

        public Day18Program(Dictionary<string, long> registers)
        {
            this.Registers = new Dictionary<string, long>(registers);
        }
    }
}