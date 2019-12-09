using System.Linq;

namespace AdventOfCode2019.IntCode.Internal
{
    internal class AddInstruction : Instruction
    {
        public AddInstruction(long instruction) : base(instruction)
        {
        }

        public override InstructionResult Execute(Machine machine)
        {
            var parameters = this.GetParameters(3, machine);

            machine.Memory[(int)parameters[2].Value] = parameters[0].Program.Value + parameters[1].Program.Value;
            machine.Position += 4;
            return new InstructionResult();
        }
    }
}