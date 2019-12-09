namespace AdventOfCode2019.IntCode.Internal
{
    internal class EqualsInstruction : Instruction
    {
        public EqualsInstruction(long instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(3, machine);

            machine.Memory[(int)parameters[2].Value] = parameters[0].Program.Value == parameters[1].Program.Value ? 1 : 0;
            machine.Position += 4;
            return new InstructionResult();
        }
    }
}