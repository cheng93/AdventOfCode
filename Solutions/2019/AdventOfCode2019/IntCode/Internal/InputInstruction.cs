using System.Linq;

namespace AdventOfCode2019.IntCode.Internal
{
    internal class InputInstruction : Instruction
    {
        public InputInstruction(long instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(1, machine);

            machine.Memory[(int)parameters[0].Value] = machine.GetCurrentInput();
            machine.Position += 2;
            return new InstructionResult()
            {
                ProcessedInput = true
            };
        }
    }
}