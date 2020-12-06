using AdventOfCode2020.Day06;
using Xunit;

namespace AdventOfCode2020.Tests.Day06
{
    public class Day06SolverTests
    {
        private readonly Day06Solver subject = new Day06Solver();

        public static TheoryData<int, string> PuzzleOneTestData
            = new TheoryData<int, string>()
            {
                {
                    11,
@"abc

a
b
c

ab
ac

a
a
a
a

b"
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
                    6,
@"abc

a
b
c

ab
ac

a
a
a
a

b"
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