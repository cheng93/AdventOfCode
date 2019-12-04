using AdventOfCode2019.Day04;
using Xunit;

namespace AdventOfCode2019.Tests.Day04
{
    public class Day04ValidatorTests
    {
        private readonly Day04Validator subject = new Day04Validator();

        [Theory]
        [InlineData(true, 111111)]
        [InlineData(true, 111123)]
        [InlineData(true, 135779)]
        [InlineData(false, 223450)]
        [InlineData(false, 123789)]
        [InlineData(false, 12378)]
        [InlineData(false, 1237823)]
        public void IsValidOne(bool expected, int input)
        {
            var actual = this.subject.IsValidOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, 112233)]
        [InlineData(true, 135779)]
        [InlineData(true, 111122)]
        [InlineData(false, 111111)]
        [InlineData(false, 123444)]
        [InlineData(false, 111123)]
        [InlineData(false, 223450)]
        [InlineData(false, 123789)]
        [InlineData(false, 12378)]
        [InlineData(false, 1237823)]
        public void IsValidTwo(bool expected, int input)
        {
            var actual = this.subject.IsValidTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}