namespace AdventOfCode.Console
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;
    using AdventOfCode2017;
    using AdventOfCode2018;
    using CommandLine;
    using Console = System.Console;

    class Program
    {
        private static IDictionary<int, IPuzzleFactory> puzzleFactories = new Dictionary<int, IPuzzleFactory>()
        {
            {2017, new Year2017PuzzleFactory()},
            {2018, new Year2018PuzzleFactory()}
        };

        public static async Task Main(string[] args)
        {

            var parsed = Parser.Default.ParseArguments<ConsoleOptions>(args);

            await parsed.MapResult(
                async options =>
                {
                    var puzzle = puzzleFactories[options.Year].Create(options.Day);

                    await Execute(() => puzzle.PuzzleOne());
                    await Execute(() => puzzle.PuzzleTwo());
                },
                errors => Task.CompletedTask);

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
