using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IntCode.Internal;

namespace AdventOfCode2019.IntCode
{
    public class Machine
    {
        public Machine(IEnumerable<long> memory, IEnumerable<int> inputs)
        {
            this.Memory = new Memory(memory);
            this.inputs = inputs.ToList();
        }

        internal Memory Memory { get; private set; }

        internal int Position { get; set; } = 0;

        internal int RelativeBase { get; set; } = 0;

        public IEnumerable<long> Run()
        {
            while (true)
            {
                var instruction = Instruction.Create(this);
                var result = instruction.Execute(this);
                if (result.Halt)
                {
                    break;
                }
                if (result.ProcessedInput)
                {
                    this.inputsProcessed++;
                }
                if (result.Output.HasValue)
                {
                    yield return result.Output.Value;
                }
            }
        }

        internal int GetCurrentInput() => this.inputs[inputsProcessed];

        private List<int> inputs;
        private int inputsProcessed = 0;
    }
}