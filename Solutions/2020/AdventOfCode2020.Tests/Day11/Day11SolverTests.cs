using System.Collections.Generic;
using AdventOfCode2020.Day11;
using Xunit;

namespace AdventOfCode2020.Tests.Day11
{
    public class Day11SolverTests
    {
        private readonly Day11Solver subject = new Day11Solver();

        public static TheoryData<int, string> PuzzleOneTestData
            = new TheoryData<int, string>()
            {
                {
                    37,
@"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL"
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<int, string> PuzzleTwoTestData
            = new TheoryData<int, string>()
            {
                {
                    26,
@"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL"
                }
            };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}