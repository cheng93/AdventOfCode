namespace AdventOfCode2018.Tests.Day17
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day17;
    using Xunit;

    public class Day17SolverTests
    {
        private readonly Day17Solver subject = new Day17Solver();

        private static readonly IEnumerable<string> TestData1 = new[]
        {
            "x=495, y=2..7",
            "y=7, x=495..501",
            "x=501, y=3..7",
            "x=498, y=2..4",
            "x=506, y=1..2",
            "x=498, y=10..13",
            "x=504, y=10..13",
            "y=13, x=498..504"
        };

        private static readonly IEnumerable<string> TestData2 = new[]
        {
            "x=495, y=12..17",
            "y=17, x=495..501",
            "x=501, y=13..17",
            "x=498, y=12..14",
            "x=506, y=11..12",
            "x=498, y=20..23",
            "x=504, y=20..23",
            "y=23, x=498..504"
        };

        public static readonly IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 57, TestData1 },
            new object[] { 57, TestData2 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static readonly IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 29, TestData1 },
            new object[] { 29, TestData2 }
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(int expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}