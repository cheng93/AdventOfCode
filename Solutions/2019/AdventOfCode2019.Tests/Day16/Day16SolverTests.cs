using System.Linq;
using AdventOfCode2019.Day16;
using Xunit;

namespace AdventOfCode2019.Tests.Day16
{
    public class Day16SolverTests
    {
        private readonly Day16Solver subject = new Day16Solver();

        [Theory]
        [InlineData("01029498", 4, 1, 2, 3, 4, 5, 6, 7, 8)]
        [InlineData("24176176", 100, 8, 0, 8, 7, 1, 2, 2, 4, 5, 8, 5, 9, 1, 4, 5, 4, 6, 6, 1, 9, 0, 8, 3, 2, 1, 8, 6, 4, 5, 5, 9, 5)]
        [InlineData("73745418", 100, 1, 9, 6, 1, 7, 8, 0, 4, 2, 0, 7, 2, 0, 2, 2, 0, 9, 1, 4, 4, 9, 1, 6, 0, 4, 4, 1, 8, 9, 9, 1, 7)]
        [InlineData("52432133", 100, 6, 9, 3, 1, 7, 1, 6, 3, 4, 9, 2, 9, 4, 8, 6, 0, 6, 3, 3, 5, 9, 9, 5, 9, 2, 4, 3, 1, 9, 8, 7, 3)]
        public void PuzzleOne(string expected, int phases, params int[] input)
        {
            var actual = this.subject.PuzzleOne(input, phases);
            var str = string.Join(string.Empty, actual.Take(8));

            Assert.Equal(expected, str);
        }

        [Theory]
        [InlineData("84462026", 0, 3, 0, 3, 6, 7, 3, 2, 5, 7, 7, 2, 1, 2, 9, 4, 4, 0, 6, 3, 4, 9, 1, 5, 6, 5, 4, 7, 4, 6, 6, 4)]
        [InlineData("78725270", 0, 2, 9, 3, 5, 1, 0, 9, 6, 9, 9, 9, 4, 0, 8, 0, 7, 4, 0, 7, 5, 8, 5, 4, 4, 7, 0, 3, 4, 3, 2, 3)]
        [InlineData("53553731", 0, 3, 0, 8, 1, 7, 7, 0, 8, 8, 4, 9, 2, 1, 9, 5, 9, 7, 3, 1, 1, 6, 5, 4, 4, 6, 8, 5, 0, 5, 1, 7)]
        public void PuzzleTwo(string expected, params int[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}