
namespace AdventOfCode2018.Tests.Day02
{
    using AdventOfCode2018.Day02;
    using Xunit;

    public class Day02SolverTests
    {
        private readonly Day02Solver subject = new Day02Solver();

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