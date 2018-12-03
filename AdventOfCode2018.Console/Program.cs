namespace AdventOfCode2018.Console
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DayOne;
    using DayTwo;
    using Console = System.Console;

    class Program
    {
        private static IDictionary<int, IPuzzle> puzzles = new Dictionary<int, IPuzzle>()
        {
            {1, new DayOnePuzzle()},
            {2, new DayTwoPuzzle()}
        };

        public static async Task Main(string[] args)
        {
            var puzzleNumber = int.Parse(Console.ReadLine());
            var puzzle = puzzles[puzzleNumber];

            try
            {
                Console.WriteLine(await puzzle.PuzzleOne());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Console.WriteLine(await puzzle.PuzzleTwo());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
