using AdventOfCode2019.Day08;
using Xunit;

namespace AdventOfCode2019.Tests.Day08
{
    public class Day08SolverTests
    {
        private readonly Day08Solver subject = new Day08Solver();

        [Theory]
        [InlineData(1, 3, 2, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2)]
        public void PuzzleOne(int expected, int width, int height, params int[] input)
        {
            var actual = this.subject.PuzzleOne(input, width, height);

            Assert.Equal(expected, actual);
        }

        private const string PuzzleTwoExpected = @".#
#.";
        [Theory]
        [InlineData(PuzzleTwoExpected, 2, 2, 0, 2, 2, 2, 1, 1, 2, 2, 2, 2, 1, 2, 0, 0, 0, 0)]
        public void PuzzleTwo(string expected, int width, int height, params int[] input)
        {
            var actual = this.subject.PuzzleTwo(input, width, height);

            Assert.Equal(expected, actual);
        }
    }
}