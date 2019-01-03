namespace AdventOfCode.Console
{
    using CommandLine;

    public class ConsoleOptions
    {
        [Option('y', "year", HelpText = "The Advent of Code year.")]
        public int Year { get; set; }

        [Option('d', "day", HelpText = "The advent day.")]
        public int Day { get; set; }

        [Option("debug", HelpText = "The advent day.")]
        public bool Debug { get; set; }
    }
}