using AdventOfCode2019.Day22;
using Xunit;

namespace AdventOfCode2019.Tests.Day22
{
    public class Day22SolverTests
    {
        private readonly Day22Solver subject = new Day22Solver();

        [Theory]
        [InlineData("0 3 6 9 2 5 8 1 4 7", 10, "deal with increment 7", "deal into new stack", "deal into new stack")]
        [InlineData("3 0 7 4 1 8 5 2 9 6", 10, "cut 6", "deal with increment 7", "deal into new stack")]
        [InlineData("6 3 0 7 4 1 8 5 2 9", 10, "deal with increment 7", "deal with increment 9", "cut -2")]
        [InlineData("9 2 5 8 1 4 7 0 3 6", 10, "deal into new stack", "cut -2", "deal with increment 7", "cut 8", "cut -4", "deal with increment 7", "cut 3", "deal with increment 9", "deal with increment 3", "cut -1")]
        public void PuzzleOne(string expected, int cards, params string[] input)
        {
            var actual = this.subject.PuzzleOne(input, cards);
            var str = string.Join(' ', actual);

            Assert.Equal(expected, str);
        }
    }
}