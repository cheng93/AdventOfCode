namespace AdventOfCode2018.Tests.Day23
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day23;
    using Xunit;

    public class Day23SolverTests
    {
        private readonly Day23Solver subject = new Day23Solver();

        private static IEnumerable<string> TestData1 = new[]
        {
            "pos=<0,0,0>, r=4",
            "pos=<1,0,0>, r=1",
            "pos=<4,0,0>, r=3",
            "pos=<0,2,0>, r=1",
            "pos=<0,5,0>, r=3",
            "pos=<0,0,3>, r=1",
            "pos=<1,1,1>, r=1",
            "pos=<1,1,2>, r=1",
            "pos=<1,3,1>, r=1"
        };

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 7, TestData1 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, IEnumerable<string> input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        private static IEnumerable<string> TestData2 = new[]
        {
            "pos=<10,12,12>, r=2",
            "pos=<12,14,12>, r=2",
            "pos=<16,12,12>, r=4",
            "pos=<14,14,14>, r=6",
            "pos=<50,50,50>, r=200",
            "pos=<10,10,10>, r=5"
        };

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 36, TestData2 }
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