
namespace AdventOfCode2018.Tests.DayTwo
{
    using AdventOfCode2018.DayTwo;
    using Xunit;

    public class DayTwoSolverTests
    {
        private readonly DayTwoSolver subject = new DayTwoSolver();

        [Theory]
        [InlineData(12, "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab")]
        public void PuzzleOne(int expected, params string[] input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("fgij", "abcde", "fghij", "klmno", "pqrst", "fguij", "axcye", "wvxyz")]
        public void PuzzleTwo(string expected, params string[] input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}