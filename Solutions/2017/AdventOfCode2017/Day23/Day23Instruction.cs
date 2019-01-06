namespace AdventOfCode2017.Day23
{
    public class Day23Instruction
    {
        public string Operation { get; }

        public string X { get; }

        public int? XNumber
        {
            get
            {
                if (int.TryParse(this.X, out var number))
                {
                    return number;
                }
                return null;
            }
        }

        public string Y { get; }

        public int? YNumber
        {
            get
            {
                if (int.TryParse(this.Y, out var number))
                {
                    return number;
                }
                return null;
            }
        }

        public Day23Instruction(string input)
        {
            // Example input: jgz a -1
            var splits = input.Split(' ');

            this.Operation = splits[0];
            this.X = splits[1];
            this.Y = splits[2];
        }
    }
}