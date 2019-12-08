using AdventOfCode2019.Day02;
using Xunit;

namespace AdventOfCode2019.Tests.Day02
{
    public class Day02MachineSolverTests
    {
        private readonly Day02MachineSolver subject = new Day02MachineSolver();

        [Theory]
        [InlineData("2,0,0,0,99", 1, 0, 0, 0, 99)]
        [InlineData("2,3,0,6,99", 2, 3, 0, 3, 99)]
        [InlineData("2,4,4,5,99,9801", 2, 4, 4, 5, 99, 0)]
        [InlineData("30,1,1,4,2,5,6,0,99", 1, 1, 1, 4, 99, 5, 6, 0, 99)]
        public void PuzzleOne(string expected, params int[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

    }
}