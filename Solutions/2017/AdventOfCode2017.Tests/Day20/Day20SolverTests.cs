namespace AdventOfCode2017.Tests.Day20
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day20;
    using Xunit;

    public class Day20SolverTests
    {
        private Day20Solver subject = new Day20Solver();

        private static string TestData1 =
@"p=<3,0,0>, v=<2,0,0>, a=<-1,0,0>
p=<4,0,0>, v=<0,0,0>, a=<-2,0,0>";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 0, TestData1 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        private static string TestData2 =
@"p=<-6,0,0>, v=<3,0,0>, a=<0,0,0>
p=<-4,0,0>, v=<2,0,0>, a=<0,0,0>
p=<-2,0,0>, v=<1,0,0>, a=<0,0,0>
p=<3,0,0>, v=<-1,0,0>, a=<0,0,0>";

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 1, TestData2 }
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