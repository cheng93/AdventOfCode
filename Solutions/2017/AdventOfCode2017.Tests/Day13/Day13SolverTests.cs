namespace AdventOfCode2017.Tests.Day13
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day13;
    using Xunit;

    public class Day13SolverTests
    {
        private Day13Solver subject = new Day13Solver();

        private static string TestData =
@"0: 3
1: 2
4: 4
6: 4";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 24, TestData }
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