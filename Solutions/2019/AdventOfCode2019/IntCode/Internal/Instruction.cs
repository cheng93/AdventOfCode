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
        private readonly int instruction;

        public abstract InstructionResult Execute(Machine machine);

        public Instruction(int instruction)
        {
            this.instruction = instruction;
        }

        public Parameter[] GetParameters(int count, Machine machine)
            => machine.Memory
                .Skip(machine.Position + 1)
                .Take(3)
                .Select((x, i) =>
                    new Parameter(
                        x,
                        new Lazy<int>(() =>
                            (instruction / (int)Math.Pow(10, 2 + i)) % 10 == 0
                                ? machine.Memory[x]
                                : x)))
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
                99 => new HaltInstruction(),
                _ => throw new InvalidOperationException()
            };
        }
    }
}