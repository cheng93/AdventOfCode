namespace AdventOfCode2017.Tests.Day02
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day02;
    using Xunit;

    public class Day02SolverTests
    {
        private readonly Day02Solver subject = new Day02Solver();

        private static string TestData1 =
@"5 1 9 5
7 5 3
2 4 6 8";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 18, TestData1 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        private static string TestData2 =
@"5 9 2 8
9 4 7 3
3 8 6 5";

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 9, TestData2 }
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