namespace AdventOfCode2017.Tests.Day15
{
    using AdventOfCode2017.Day15;
    using Xunit;

    public class Day15SolverTests
    {
        private Day15Solver subject = new Day15Solver();

        [Theory]
        [InlineData(588, 65, 8921)]
        public void PuzzleOne(int expected, int a, int b)
        {
            var actual = this.subject.PuzzleOne(a, b);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(309, 65, 8921)]
        public void PuzzleTwo(int expected, int a, int b)
        {
            var actual = this.subject.PuzzleTwo(a, b);

            Assert.Equal(expected, actual);
        }
    }
}