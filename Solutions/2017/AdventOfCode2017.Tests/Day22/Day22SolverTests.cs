namespace AdventOfCode2017.Tests.Day22
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day22;
    using Xunit;

    public class Day22SolverTests
    {
        private readonly Day22Solver subject = new Day22Solver();

        private static string TestData =
@"..#
#..
...";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 5587, TestData }
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
            new object[] { 2511944, TestData }
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