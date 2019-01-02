namespace AdventOfCode2018.Tests.Day06
{
    using System.Collections.Generic;
    using System.Drawing;
    using AdventOfCode2018.Day06;
    using Xunit;

    public class Day06SolverTests
    {
        private readonly Day06Solver subject = new Day06Solver();

        private static IEnumerable<Point> TestData1 = new[]
        {
            new Point(1,1),
            new Point(1,6),
            new Point(8,3),
            new Point(3,4),
            new Point(5,5),
            new Point(8,9),
        };

        private static IEnumerable<Point> TestData2 = new[]
        {
            new Point(0,6),
            new Point(1,3),
            new Point(3,5),
            new Point(3,3),
            new Point(4,7),
            new Point(2,4),
        };

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] {17, TestData1 },
            new object[] {1, TestData2 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, params Point[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] {16, 32, TestData1 }
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(int expected, int boundary, params Point[] input)
        {
            var actual = this.subject.PuzzleTwo(input, boundary);

            Assert.Equal(expected, actual);
        }
    }
}