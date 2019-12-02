using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day02
{
    public class Day02Solver
    {
        public string PuzzleOne(IEnumerable<int> input)
        {
            var program = input.ToArray();

            var position = 0;
            var opcode = program[position];
            while (opcode != 99)
            {
                var one = program[program[position + 1]];
                var two = program[program[position + 2]];
                var three = program[position + 3];

                program[three] = opcode == 1
                    ? one + two
                    : one * two;
                position += 4;
                opcode = program[position];
            }

            return string.Join(',', program);
        }
    }
}