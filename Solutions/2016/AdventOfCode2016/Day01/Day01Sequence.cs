namespace AdventOfCode2016.Day01
{
    public class Day01Sequence
    {
        public int Blocks { get; set; }

        public bool IsLeft { get; set; }

        public Day01Sequence(string input)
        {
            // Example input: R2
            this.IsLeft = input[0] == 'L';
            this.Blocks = int.Parse(input.Substring(1));
        }
    }
}