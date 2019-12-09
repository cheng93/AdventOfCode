namespace AdventOfCode2019.IntCode.Internal
{
    internal class AdjustRelativeBaseInstruction : Instruction
    {
        public AdjustRelativeBaseInstruction(long instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(1, machine);

            machine.RelativeBase += (int)parameters[0].Program.Value;
            machine.Position += 2;
            return new InstructionResult();
        }
    }
}