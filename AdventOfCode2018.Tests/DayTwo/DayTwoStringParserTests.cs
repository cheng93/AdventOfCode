using AdventOfCode2018.DayTwo;
using Xunit;

namespace AdventOfCode2018.Tests.DayTwo
{
    public class DayTwoStringParserTests
    {
        private readonly DayTwoStringParser subject = new DayTwoStringParser();

        [Theory]
        [InlineData(false, "abcdef")]
        [InlineData(true, "bababc")]
        [InlineData(true, "abbcde")]
        [InlineData(false, "abcccd")]
        [InlineData(true, "aabcdd")]
        [InlineData(true, "abcdee")]
        [InlineData(false, "ababab")]
        public void HasTwo(bool expected, string input)
        {
            var actual = this.subject.Parse(input).HasTwo;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, "abcdef")]
        [InlineData(true, "bababc")]
        [InlineData(false, "abbcde")]
        [InlineData(true, "abcccd")]
        [InlineData(false, "aabcdd")]
        [InlineData(false, "abcdee")]
        [InlineData(true, "ababab")]
        public void HasThree(bool expected, string input)
        {
            var actual = this.subject.Parse(input).HasThree;

            Assert.Equal(expected, actual);
        }
    }
}