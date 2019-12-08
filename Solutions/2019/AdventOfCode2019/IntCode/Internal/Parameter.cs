using System;

namespace AdventOfCode2019.IntCode.Internal
{
    internal class Parameter
    {
        public Parameter(int immediate, Lazy<int> lazy)
        {
            this.Mode = lazy;
            this.Immediate = immediate;

        }

        public int Immediate { get; }
        public Lazy<int> Mode { get; }
    }
}