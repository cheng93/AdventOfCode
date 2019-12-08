using System.Linq;

namespace AdventOfCode2019.IntCode.Internal
{
    internal class MultiplyInstruction : Instruction
    {
        public MultiplyInstruction(int instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(3, machine);

            machine.Memory[parameters[2].Immediate] = parameters[0].Mode.Value * parameters[1].Mode.Value;
            return new InstructionResult(machine)
            {
                Position = machine.Position + 4
            };
        }
    }
}