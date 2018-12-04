namespace AdventOfCode2018.Console
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Day01;
    using Day02;
    using Day03;
    using Day04;
    using Console = System.Console;

    class Program
    {
        private static IDictionary<int, IPuzzle> puzzles = new Dictionary<int, IPuzzle>()
        {
            {1, new Day01Puzzle()},
            {2, new Day02Puzzle()},
            {3, new Day03Puzzle()},
            {4, new Day04Puzzle()}
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
