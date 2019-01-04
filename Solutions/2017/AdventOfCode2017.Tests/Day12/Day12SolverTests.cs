namespace AdventOfCode2017.Tests.Day12
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day12;
    using Xunit;

    public class Day12SolverTests
    {
        private Day12Solver subject = new Day12Solver();

        private static string TestData =
@"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 6, TestData }
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
            new object[] { 2, TestData }
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