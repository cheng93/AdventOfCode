namespace AdventOfCode2019.IntCode.Internal
{
    internal class OutputInstruction : Instruction
    {
        public OutputInstruction(int instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(1, machine);

            return new InstructionResult(machine)
            {
                Output = parameters[0].Mode.Value,
                Position = machine.Position + 2
            };
        }
    }
}