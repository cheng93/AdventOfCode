namespace AdventOfCode.Console
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using AdventOfCode.Abstractions;
    using AdventOfCode2016;
    using AdventOfCode2017;
    using AdventOfCode2018;
    using AdventOfCode2019;
    using AdventOfCode2020;
    using AdventOfCode2021;
    using CommandLine;
    using Console = System.Console;

    class Program
    {
        private static IDictionary<int, IPuzzleFactory> puzzleFactories = new Dictionary<int, IPuzzleFactory>()
        {
            {2016, new Year2016PuzzleFactory()},
            {2017, new Year2017PuzzleFactory()},
            {2018, new Year2018PuzzleFactory()},
            {2019, new Year2019PuzzleFactory()},
            {2020, new Year2020PuzzleFactory()},
            {2021, new Year2021PuzzleFactory()}
        };

        public static async Task Main(string[] args)
        {

            var parsed = Parser.Default.ParseArguments<ConsoleOptions>(args);

            await parsed.MapResult(
                async options =>
                {
                    if (options.Debug)
                    {
                        Console.WriteLine("Debugging...");
                        Console.ReadLine();
                    }
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
