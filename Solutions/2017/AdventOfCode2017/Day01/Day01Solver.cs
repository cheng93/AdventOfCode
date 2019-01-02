namespace AdventOfCode2017.Day01
{
    public class Day01Solver
    {
        public int PuzzleOne(string input)
        {
            var sum = 0;

            for (var i = 0; i < input.Length; i++)
            {
                var next = input[(i + 1) % input.Length];

                if (input[i] == next)
                {
                    sum += int.Parse(input[i].ToString());
                }
            }

            return sum;
        }

        public int PuzzleTwo(string input)
        {
            var sum = 0;

            for (var i = 0; i < input.Length; i++)
            {
                var next = input[(i + (input.Length / 2)) % input.Length];

                if (input[i] == next)
                {
                    sum += int.Parse(input[i].ToString());
                }
            }

            return sum;
        }
    }
}