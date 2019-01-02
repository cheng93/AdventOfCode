namespace AdventOfCode2018.Day16
{
    using System.Collections.Generic;
    using System.Linq;

    public class Day16Instruction
    {
        public int Opcode { get; }

        public int A { get; }

        public int B { get; }

        public int Output { get; }

        public Day16Instruction(string input)
        {
            // Example input: 9 2 1 2
            var splits = input
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            this.Opcode = splits[0];
            this.A = splits[1];
            this.B = splits[2];
            this.Output = splits[3];
        }

        public int[] Execute(IDictionary<int, string> opCodeMap, int[] input)
        {
            var operation = opCodeMap[this.Opcode];
            var output = input.ToArray();
            switch (operation)
            {
                case "addr":
                    output[this.Output] = input[this.A] + input[this.B];
                    break;
                case "addi":
                    output[this.Output] = input[this.A] + this.B;
                    break;
                case "mulr":
                    output[this.Output] = input[this.A] * input[this.B];
                    break;
                case "muli":
                    output[this.Output] = input[this.A] * this.B;
                    break;
                case "banr":
                    output[this.Output] = input[this.A] & input[this.B];
                    break;
                case "bani":
                    output[this.Output] = input[this.A] & this.B;
                    break;
                case "borr":
                    output[this.Output] = input[this.A] | input[this.B];
                    break;
                case "bori":
                    output[this.Output] = input[this.A] | this.B;
                    break;
                case "setr":
                    output[this.Output] = input[this.A];
                    break;
                case "seti":
                    output[this.Output] = this.A;
                    break;
                case "gtir":
                    output[this.Output] = this.A > input[this.B] ? 1 : 0;
                    break;
                case "gtri":
                    output[this.Output] = input[this.A] > this.B ? 1 : 0;
                    break;
                case "gtrr":
                    output[this.Output] = input[this.A] > input[this.B] ? 1 : 0;
                    break;
                case "eqir":
                    output[this.Output] = this.A == input[this.B] ? 1 : 0;
                    break;
                case "eqri":
                    output[this.Output] = input[this.A] == this.B ? 1 : 0;
                    break;
                case "eqrr":
                    output[this.Output] = input[this.A] == input[this.B] ? 1 : 0;
                    break;
                default:
                    throw new System.InvalidOperationException();
            }

            return output;
        }
    }
}