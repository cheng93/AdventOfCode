namespace AdventOfCode2019.IntCode.Internal
{
    internal class JumpTrueInstruction : Instruction
    {
        public JumpTrueInstruction(int instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(2, machine);
            return new InstructionResult(machine)
            {
                Position = parameters[0].Mode.Value != 0
                    ? parameters[1].Mode.Value
                    : machine.Position + 3
            };
        }
    }
}