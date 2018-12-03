namespace AdventOfCode2018.Tests.DayOne
{
    using AdventOfCode2018.DayOne;
    using Xunit;

    public class DayOneSolverTests
    {
        public DayOneSolver Subject = new DayOneSolver();

        [Theory]
        [InlineData(3, 1, -2, 3, 1)]
        [InlineData(3, 1, 1, 1)]
        [InlineData(0, 1, 1, -2)]
        [InlineData(-6, -1, -2, -3)]
        public void PuzzleOne(int expected, params int[] input)
        {
            var actual = this.Subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 1, -2, 3, 1)]
        [InlineData(0, 1, -1)]
        [InlineData(10, 3, 3, 4, -2, -4)]
        [InlineData(5, -6, 3, 8, 5, -6)]
        [InlineData(14, 7, 7, -2, -7, -4)]
        public void PuzzleTwo(int expected, params int[] input)
        {
            var actual = this.Subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}
