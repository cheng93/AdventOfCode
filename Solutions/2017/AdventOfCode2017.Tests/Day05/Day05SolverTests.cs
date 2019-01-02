namespace AdventOfCode2017.Tests.Day05
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day05;
    using Xunit;

    public class Day05SolverTests
    {
        private readonly Day05Solver subject = new Day05Solver();

        private static string TestData =
@"0
3
0
1
-3";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 5, TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 10, TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}