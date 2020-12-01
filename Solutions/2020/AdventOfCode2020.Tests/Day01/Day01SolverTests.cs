using AdventOfCode2020.Day01;
using Xunit;

namespace AdventOfCode2020.Tests.Day01
{
    public class Day01SolverTest
    {
        private readonly Day01Solver subject = new Day01Solver();

        [Theory]
        [InlineData(514579, 1721, 979, 366, 299, 675, 1456)]
        public void PuzzleOne(int expected, params int[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(241861950, 1721, 979, 366, 299, 675, 1456)]
        public void PuzzleTwo(int expected, params int[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}