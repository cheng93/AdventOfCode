namespace AdventOfCode2018.Console
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AdventOfCode2018.Day01;
    using AdventOfCode2018.Day02;
    using AdventOfCode2018.Day03;
    using AdventOfCode2018.Day04;
    using AdventOfCode2018.Day05;
    using AdventOfCode2018.Day06;
    using AdventOfCode2018.Day07;
    using Console = System.Console;

    class Program
    {
        private static IDictionary<int, IPuzzle> puzzles = new Dictionary<int, IPuzzle>()
        {
            {1, new Day01Puzzle()},
            {2, new Day02Puzzle()},
            {3, new Day03Puzzle()},
            {4, new Day04Puzzle()},
            {5, new Day05Puzzle()},
            {6, new Day06Puzzle()},
            {7, new Day07Puzzle()}
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
