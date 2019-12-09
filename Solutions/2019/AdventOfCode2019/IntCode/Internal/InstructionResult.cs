namespace AdventOfCode2019.IntCode
{
    internal class InstructionResult
    {
        public bool Halt { get; set; }
        public bool ProcessedInput { get; set; }
        public long? Output { get; set; }
    }
}