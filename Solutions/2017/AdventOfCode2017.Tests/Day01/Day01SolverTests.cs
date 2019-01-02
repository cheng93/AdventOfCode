namespace AdventOfCode2017.Tests.Day01
{
    using AdventOfCode2017.Day01;
    using Xunit;

    public class Day01SolverTests
    {
        private readonly Day01Solver subject = new Day01Solver();

        [Theory]
        [InlineData(3, "1122")]
        [InlineData(4, "1111")]
        [InlineData(0, "1234")]
        [InlineData(9, "91212129")]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(6, "1212")]
        [InlineData(0, "1221")]
        [InlineData(4, "123425")]
        [InlineData(12, "123123")]
        [InlineData(4, "12131415")]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}