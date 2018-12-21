namespace AdventOfCode2018.Day21
{
    using System.Collections.Generic;
    using System.Linq;

    public class Day21Instruction
    {
        public string Operation { get; }

        public int A { get; }

        public int B { get; }

        public int Output { get; }

        public Day21Instruction(string input)
        {
            // Example input: seti 5 0 1
            var splits = input
                .Split(' ')
                .ToArray();

            this.Operation = splits[0];
            this.A = int.Parse(splits[1]);
            this.B = int.Parse(splits[2]);
            this.Output = int.Parse(splits[3]);
        }

        public int[] Execute(int[] input)
        {
            var output = input.ToArray();
            switch (this.Operation)
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
                    output[this.Output] = output[this.A];
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

        public override string ToString() => $"{Operation} {A} {B} {Output}";
    }
}