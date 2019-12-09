namespace AdventOfCode2019.IntCode.Internal
{
    internal class JumpTrueInstruction : Instruction
    {
        public JumpTrueInstruction(long instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(2, machine);
            machine.Position = parameters[0].Program.Value != 0
                    ? (int)parameters[1].Program.Value
                    : machine.Position + 3;
            return new InstructionResult();
        }
    }
}