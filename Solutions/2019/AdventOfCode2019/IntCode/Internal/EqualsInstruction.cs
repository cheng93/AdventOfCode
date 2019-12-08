namespace AdventOfCode2019.IntCode.Internal
{
    internal class EqualsInstruction : Instruction
    {
        public EqualsInstruction(int instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(3, machine);

            machine.Memory[parameters[2].Immediate] = parameters[0].Mode.Value == parameters[1].Mode.Value ? 1 : 0;
            return new InstructionResult(machine)
            {
                Position = machine.Position + 4
            };
        }
    }
}