namespace AdventOfCode2018.Tests.Day25
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day25;
    using Xunit;

    public class Day25SolverTests
    {
        private readonly Day25Solver subject = new Day25Solver();

        private static IEnumerable<string> TestData1 = new[]
        {
            " 0,0,0,0",
            " 3,0,0,0",
            " 0,3,0,0",
            " 0,0,3,0",
            " 0,0,0,3",
            " 0,0,0,6",
            " 9,0,0,0",
            "12,0,0,0"
        };

        private static IEnumerable<string> TestData2 = new[]
        {
            "-1,2,2,0",
            "0,0,2,-2",
            "0,0,0,-2",
            "-1,2,0,0",
            "-2,-2,-2,2",
            "3,0,2,-1",
            "-1,3,2,2",
            "-1,0,-1,0",
            "0,2,1,-2",
            "3,0,0,0"
        };

        private static IEnumerable<string> TestData3 = new[]
        {
            "1,-1,0,1",
            "2,0,-1,0",
            "3,2,-1,0",
            "0,0,3,1",
            "0,0,-1,-1",
            "2,3,-2,0",
            "-2,2,0,0",
            "2,-2,0,-1",
            "1,-1,0,-1",
            "3,2,0,2"
        };

        private static IEnumerable<string> TestData4 = new[]
        {
            "1,-1,-1,-2",
            "-2,-2,0,1",
            "0,2,1,3",
            "-2,3,-2,1",
            "0,2,3,-2",
            "-1,-1,1,-2",
            "0,-2,-1,0",
            "-2,2,3,-1",
            "1,2,2,0",
            "-1,-2,0,-2"
        };

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 2, TestData1 },
            new object[] { 4, TestData2 },
            new object[] { 3, TestData3 },
            new object[] { 8, TestData4 },
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}