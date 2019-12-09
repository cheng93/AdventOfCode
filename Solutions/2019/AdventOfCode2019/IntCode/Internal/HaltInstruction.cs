namespace AdventOfCode2019.IntCode.Internal
{
    internal class HaltInstruction : IInstruction
    {
        public InstructionResult Execute(Machine machine)
        {
            return new InstructionResult()
            {
                Halt = true
            };
        }
    }
}