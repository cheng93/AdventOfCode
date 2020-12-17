using AdventOfCode2020.Day17;
using Xunit;

namespace AdventOfCode2020.Tests.Day17
{
    public class Day17SolverTests
    {
        private readonly Day17Solver subject = new Day17Solver();

        public static TheoryData<int, string> PuzzleOneTestData
            = new TheoryData<int, string>()
            {
                {
                    112,
@".#.
..#
###
"
                },
            };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(long expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static TheoryData<int, string> PuzzleTwoTestData
            = new TheoryData<int, string>()
            {
                {
                    848,
@".#.
..#
###
"
                },
            };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(long expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}