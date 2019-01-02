namespace AdventOfCode2017.Tests.Day03
{
    using AdventOfCode2017.Day03;
    using Xunit;

    public class Day03SolverTests
    {
        private readonly Day03Solver subject = new Day03Solver();

        [Theory]
        [InlineData(0, 1)]
        [InlineData(3, 12)]
        [InlineData(2, 23)]
        [InlineData(31, 1024)]
        public void PuzzleOne(int expected, int input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(23, 12)]
        [InlineData(25, 23)]
        [InlineData(806, 748)]
        public void PuzzleTwo(int expected, int input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}