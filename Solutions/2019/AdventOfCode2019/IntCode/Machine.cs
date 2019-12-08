using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IntCode.Internal;

namespace AdventOfCode2019.IntCode
{
    public class Machine
    {
        public Machine(int[] memory, IEnumerable<int> inputs)
        {
            this.Memory = memory;
            this.inputs = inputs.ToList();
        }

        public int[] Memory { get; private set; }

        public int Position { get; private set; } = 0;

        public IEnumerable<int> Run()
        {
            while (true)
            {
                var instruction = Instruction.Create(this);
                var result = instruction.Execute(this);
                if (result.Halt)
                {
                    break;
                }
                this.Position = result.Position;
                this.Memory = result.Memory;
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

        public int GetCurrentInput() => this.inputs[inputsProcessed];

        private List<int> inputs;
        private int inputsProcessed = 0;
    }
}