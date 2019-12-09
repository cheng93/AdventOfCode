namespace AdventOfCode2019.IntCode.Internal
{
    internal class OutputInstruction : Instruction
    {
        public OutputInstruction(long instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(1, machine);
            machine.Position += 2;

            return new InstructionResult()
            {
                Output = parameters[0].Program.Value
            };
        }
    }
}