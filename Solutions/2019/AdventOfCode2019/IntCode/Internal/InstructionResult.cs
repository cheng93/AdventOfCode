namespace AdventOfCode2019.IntCode
{
    internal class InstructionResult
    {
        public InstructionResult(Machine machine)
        {
            this.Memory = machine.Memory;
            this.Position = machine.Position;
        }

        public int[] Memory { get; set; }
        public bool Halt { get; set; }
        public int Position { get; set; }
        public bool ProcessedInput { get; set; }
        public int? Output { get; set; }
    }
}