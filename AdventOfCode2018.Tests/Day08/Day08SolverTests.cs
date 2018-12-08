namespace AdventOfCode2018.Tests.Day08
{
    using AdventOfCode2018.Day08;
    using Xunit;

    public class Day08SolverTests
    {
        private readonly Day08Solver subject = new Day08Solver();

        [Theory]
        [InlineData(138, 2, 3, 0, 3, 10, 11, 12, 1, 1, 0, 1, 99, 2, 1, 1, 2)]
        public void PuzzleOne(int expected, params int[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(66, 2, 3, 0, 3, 10, 11, 12, 1, 1, 0, 1, 99, 2, 1, 1, 2)]
        [InlineData(88, 2, 3, 1, 3, 0, 1, 22, 1, 1, 2, 1, 1, 0, 1, 99, 2, 1, 1, 2)]
        public void PuzzleTwo(int expected, params int[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}