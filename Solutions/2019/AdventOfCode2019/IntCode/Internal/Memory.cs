using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.IntCode.Internal
{
    public class Memory : IEnumerable<long>
    {
        private readonly List<long> input;
        public Memory(IEnumerable<long> input)
        {
            this.input = input.ToList();
        }

        public long this[int index]
        {
            get
            {
                Expand(index);
                return this.input[index];
            }
            set
            {
                Expand(index);
                this.input[index] = value;
            }
        }

        private void Expand(int size)
        {
            while (this.input.Count <= size)
            {
                this.input.Add(0);
            }
        }

        public IEnumerator<long> GetEnumerator() => this.input.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}