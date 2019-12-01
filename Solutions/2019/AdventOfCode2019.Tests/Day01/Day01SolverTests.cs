using Xunit;
using AdventOfCode2019.Day01;

namespace AdventOfCode2019.Tests.Day01
{
    public class Day01SolverTests
    {
        private readonly Day01Solver subject = new Day01Solver();

        [Theory]
        [InlineData(2, 12)]
        [InlineData(2, 14)]
        [InlineData(654, 1969)]
        [InlineData(33583, 100756)]
        public void PuzzleOne(int expected, params int[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 14)]
        [InlineData(966, 1969)]
        [InlineData(50346, 100756)]
        public void PuzzleTwo(int expected, params int[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}