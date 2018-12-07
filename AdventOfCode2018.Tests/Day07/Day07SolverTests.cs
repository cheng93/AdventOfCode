namespace AdventOfCode2018.Tests.Day07
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day07;
    using Xunit;

    public class Day07SolverTests
    {
        private readonly Day07Solver subject = new Day07Solver();

        private static readonly IEnumerable<string> TestData = new[]
        {
            "Step C must be finished before step A can begin.",
            "Step C must be finished before step F can begin.",
            "Step A must be finished before step B can begin.",
            "Step A must be finished before step D can begin.",
            "Step B must be finished before step E can begin.",
            "Step D must be finished before step E can begin.",
            "Step F must be finished before step E can begin."
        };

        public static readonly IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { "CABDFE", TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(string expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static readonly IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 15, TestData, 2, 0 },
            new object[] { 258, TestData, 2, 60 }
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(int expected, IEnumerable<string> input, int workers, int buffer)
        {
            var actual = this.subject.PuzzleTwo(input, workers, buffer);

            Assert.Equal(expected, actual);
        }
    }
}