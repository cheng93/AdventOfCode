using System;
using System.Linq;

namespace AdventOfCode2019.IntCode.Internal
{
    internal interface IInstruction
    {
        InstructionResult Execute(Machine machine);
    }

    internal abstract class Instruction : IInstruction
    {
        private readonly long instruction;

        public abstract InstructionResult Execute(Machine machine);

        public Instruction(long instruction)
        {
            this.instruction = instruction;
        }

        public Parameter[] GetParameters(int count, Machine machine)
            => machine.Memory
                .Skip(machine.Position + 1)
                .Take(3)
                .Select((x, i) =>
                    ((instruction / (long)Math.Pow(10, 2 + i)) % 10) switch
                    {
                        0 => new Parameter(x, () => machine.Memory[(int)x]),
                        1 => new Parameter(x, () => x),
                        2 => new Parameter(x + machine.RelativeBase, () => machine.Memory[(int)x + machine.RelativeBase]),
                        _ => throw new InvalidOperationException()
                    })
                .ToArray();

        public static IInstruction Create(Machine machine)
        {
            var instruction = machine.Memory[machine.Position];
            var opCode = instruction % 100;

            return opCode switch
            {
                1 => new AddInstruction(instruction),
                2 => new MultiplyInstruction(instruction),
                3 => new InputInstruction(instruction),
                4 => new OutputInstruction(instruction),
                5 => new JumpTrueInstruction(instruction),
                6 => new JumpFalseInstruction(instruction),
                7 => new LessThanInstruction(instruction),
                8 => new EqualsInstruction(instruction),
                9 => new AdjustRelativeBaseInstruction(instruction),
                99 => new HaltInstruction(),
                _ => throw new InvalidOperationException()
            };
        }
    }
}