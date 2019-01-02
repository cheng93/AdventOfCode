namespace AdventOfCode2018.Tests.Day09
{
    using AdventOfCode2018.Day09;
    using Xunit;

    public class Day09SolverTests
    {
        private readonly Day09Solver subject = new Day09Solver();

        [Theory]
        [InlineData(32, "9 players; last marble is worth 25 points")]
        [InlineData(8317, "10 players; last marble is worth 1618 points")]
        [InlineData(146373, "13 players; last marble is worth 7999 points")]
        [InlineData(2764, "17 players; last marble is worth 1104 points")]
        [InlineData(54718, "21 players; last marble is worth 6111 points")]
        [InlineData(37305, "30 players; last marble is worth 5807 points")]
        public void PuzzleOne(long expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(32, "9 players; last marble is worth 25 points")]
        [InlineData(8317, "10 players; last marble is worth 1618 points")]
        [InlineData(146373, "13 players; last marble is worth 7999 points")]
        [InlineData(2764, "17 players; last marble is worth 1104 points")]
        [InlineData(54718, "21 players; last marble is worth 6111 points")]
        [InlineData(37305, "30 players; last marble is worth 5807 points")]
        public void PuzzleTwo(long expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}