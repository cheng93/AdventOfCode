namespace AdventOfCode2017.Tests.Day18
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day18;
    using Xunit;

    public class Day18SolverTests
    {
        private Day18Solver subject = new Day18Solver();

        private static string TestData1 =
@"set a 1
add a 2
mul a a
mod a 5
snd a
set a 0
rcv a
jgz a -1
set a 1
jgz a -2";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 4, TestData1 }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(long expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        private static string TestData2 =
@"snd 1
snd 2
snd p
rcv a
rcv b
rcv c
rcv d";

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { 3, TestData2 }
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