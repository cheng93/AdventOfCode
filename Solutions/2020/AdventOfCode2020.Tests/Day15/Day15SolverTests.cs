using AdventOfCode2020.Day15;
using Xunit;

namespace AdventOfCode2020.Tests.Day15
{
    public class Day15SolverTest
    {
        private readonly Day15Solver subject = new Day15Solver();

        [Theory]
        [InlineData(436, 0, 3, 6)]
        [InlineData(1, 1, 3, 2)]
        [InlineData(10, 2, 1, 3)]
        [InlineData(27, 1, 2, 3)]
        [InlineData(78, 2, 3, 1)]
        [InlineData(438, 3, 2, 1)]
        [InlineData(1836, 3, 1, 2)]
        public void PuzzleOne(int expected, params int[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        // [Theory]
        // [InlineData(241861950, 1721, 979, 366, 299, 675, 1456)]
        // public void PuzzleTwo(int expected, params int[] input)
        // {
        //     var actual = this.subject.PuzzleTwo(input);

        //     Assert.Equal(expected, actual);
        // }
    }
}