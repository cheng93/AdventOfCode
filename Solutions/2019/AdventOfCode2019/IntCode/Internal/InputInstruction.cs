using System.Linq;

namespace AdventOfCode2019.IntCode.Internal
{
    internal class InputInstruction : Instruction
    {
        public InputInstruction(int instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(1, machine);

            machine.Memory[parameters[0].Immediate] = machine.GetCurrentInput();
            return new InstructionResult(machine)
            {
                ProcessedInput = true,
                Position = machine.Position + 2
            };
        }
    }
}