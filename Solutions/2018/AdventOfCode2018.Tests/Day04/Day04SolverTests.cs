namespace AdventOfCode2018.Tests.Day04
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day04;
    using Xunit;

    public class Day04SolverTests
    {
        private readonly Day04Solver subject = new Day04Solver();

        private static IEnumerable<string> OrderedMessage = new[]
        {
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-03 00:05] Guard #10 begins shift",
            "[1518-11-03 00:24] falls asleep",
            "[1518-11-03 00:29] wakes up",
            "[1518-11-04 00:02] Guard #99 begins shift",
            "[1518-11-04 00:36] falls asleep",
            "[1518-11-04 00:46] wakes up",
            "[1518-11-05 00:03] Guard #99 begins shift",
            "[1518-11-05 00:45] falls asleep",
            "[1518-11-05 00:55] wakes up"
        };

        private static IEnumerable<string> RandomMessage = new[]
        {
            "[1518-11-01 00:05] falls asleep",
            "[1518-11-01 23:58] Guard #99 begins shift",
            "[1518-11-01 00:30] falls asleep",
            "[1518-11-01 00:55] wakes up",
            "[1518-11-01 00:25] wakes up",
            "[1518-11-03 00:24] falls asleep",
            "[1518-11-03 00:05] Guard #10 begins shift",
            "[1518-11-02 00:40] falls asleep",
            "[1518-11-01 00:00] Guard #10 begins shift",
            "[1518-11-05 00:55] wakes up",
            "[1518-11-03 00:29] wakes up",
            "[1518-11-04 00:36] falls asleep",
            "[1518-11-04 00:46] wakes up",
            "[1518-11-02 00:50] wakes up",
            "[1518-11-05 00:03] Guard #99 begins shift",
            "[1518-11-05 00:45] falls asleep",
            "[1518-11-04 00:02] Guard #99 begins shift"
        };

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 240, OrderedMessage },
            new object[] { 240, RandomMessage },
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 4455, OrderedMessage },
            new object[] { 4455, RandomMessage },
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}