namespace AdventOfCode2017.Tests.Day08
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day08;
    using Xunit;

    public class Day08SolverTests
    {
        private Day08Solver subject = new Day08Solver();

        private static string TestData =
@"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 1, TestData }
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