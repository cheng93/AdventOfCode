namespace AdventOfCode2016.Tests.Day08
{
    using System.Collections.Generic;
    using AdventOfCode2016.Day08;
    using FluentAssertions;
    using Xunit;

    public class Day08RectInstructionTests
    {
        private Day08RectInstruction SubjectFactory(int wide, int tall) => new Day08RectInstruction(wide, tall);

        private static string TestData1 =
@"###....
###....
.......";

        private static string TestData2 =
@"#####..
.......
.......";

        public static IEnumerable<object[]> TestInput = new[]
        {
            new object[] { 3, 2, TestData1 },
            new object[] { 5, 1, TestData2 }
        };

        [Theory]
        [MemberData(nameof(TestInput))]
        public void AllOff(int wide, int tall, string expected)
        {
            var initial =
@".......
.......
.......".ToDictionary();

            this.SubjectFactory(wide, tall).Apply(initial);

            initial.Should().Equal(expected.ToDictionary());
        }

        [Theory]
        [MemberData(nameof(TestInput))]
        public void SomeOn(int wide, int tall, string expected)
        {
            var initial =
@".##....
.......
.......".ToDictionary();

            this.SubjectFactory(wide, tall).Apply(initial);

            initial.Should().Equal(expected.ToDictionary());
        }
    }
}