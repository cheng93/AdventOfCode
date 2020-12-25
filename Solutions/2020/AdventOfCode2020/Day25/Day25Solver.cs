using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day25
{
    public class Day25Solver
    {
        public long PuzzleOne(IEnumerable<int> input)
        {
            var publicKeys = input.ToArray();

            var loopSizes = publicKeys
                .Select(x => LoopSize(x, 7))
                .ToArray();

            return Transform(publicKeys[0], loopSizes[1]);

            int LoopSize(int publicKey, int subject)
            {
                var value = 1L;
                var loopSize = 0;

                do
                {
                    value *= subject;
                    value = value % 20201227;
                    loopSize++;
                }
                while (value != publicKey);

                return loopSize;
            }

            long Transform(int publicKey, int loopSize)
            {
                var value = 1L;

                for (var i = 0; i < loopSize; i++)
                {
                    value *= publicKey;
                    value = value % 20201227;
                }

                return value;
            }
        }
    }
}