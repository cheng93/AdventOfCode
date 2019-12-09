using System;

namespace AdventOfCode2019.IntCode.Internal
{
    internal class Parameter
    {
        public Parameter(long value, Func<long> accessor)
        {
            this.Program = new Lazy<long>(accessor);
            this.Value = value;

        }

        public long Value { get; }
        public Lazy<long> Program { get; }
    }
}