namespace AdventOfCode.Console
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;
    using AdventOfCode2018;
    using Console = System.Console;

    class Program
    {
        private static IDictionary<int, IPuzzleFactory> puzzleFactories = new Dictionary<int, IPuzzleFactory>()
        {
            {2018, new Year2018PuzzleFactory()}
        };

        public static async Task Main(string[] args)
        {
            var day = int.Parse(Console.ReadLine());
            var year = 2018;
            var puzzle = puzzleFactories[year].Create(day);

            await Execute(() => puzzle.PuzzleOne());
            await Execute(() => puzzle.PuzzleTwo());

            Console.ReadLine();
        }

        private static async Task Execute(Func<Task<string>> solution)
        {
            var watch = Stopwatch.StartNew();
            try
            {
                Console.WriteLine(await solution());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            watch.Stop();
            Console.WriteLine($"Time taken: {watch.ElapsedMilliseconds}ms");
        }
    }
}
