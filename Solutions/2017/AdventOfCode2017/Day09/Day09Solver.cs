namespace AdventOfCode2017.Day09
{
    public class Day09Solver
    {
        public int PuzzleOne(string input) => Solve(input).Score;

        public int PuzzleTwo(string input) => Solve(input).Garbage;

        private static (int Score, int Garbage) Solve(string input)
        {
            var inGarbage = false;
            var open = 0;
            var score = 0;
            var garbage = 0;

            for (var i = 0; i < input.Length; i++)
            {
                var character = input[i];
                switch (character)
                {
                    case '!':
                        if (inGarbage)
                        {
                            i++;
                        }
                        continue;
                    case '<':
                        if (!inGarbage)
                        {
                            inGarbage = true;
                        }
                        else
                        {
                            garbage++;
                        }
                        break;
                    case '>':
                        if (inGarbage)
                        {
                            inGarbage = false;
                        }
                        break;
                    case '{':
                        if (!inGarbage)
                        {
                            open++;
                        }
                        else
                        {
                            garbage++;
                        }
                        break;
                    case '}':
                        if (!inGarbage && open > 0)
                        {
                            score += open;
                            open--;
                        }
                        else if (inGarbage)
                        {
                            garbage++;
                        }
                        break;
                    default:
                        if (inGarbage)
                        {
                            garbage++;
                        }
                        break;
                }
            }

            return (score, garbage);
        }
    }
}