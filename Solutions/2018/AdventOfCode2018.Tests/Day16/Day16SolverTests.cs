namespace AdventOfCode2018.Tests.Day16
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day16;
    using Xunit;

    public class Day16SolverTests
    {
        private readonly Day16Solver subject = new Day16Solver();

        private static string TestData1 =
@"Before: [3, 2, 1, 1]
9 2 1 2
After:  [3, 2, 2, 1]";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 1, TestData1 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}