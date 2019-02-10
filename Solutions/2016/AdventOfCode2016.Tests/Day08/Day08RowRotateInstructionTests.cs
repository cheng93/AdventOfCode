namespace AdventOfCode2016.Tests.Day08
{
    using System.Collections.Generic;
    using AdventOfCode2016.Day08;
    using FluentAssertions;
    using Xunit;

    public class Day08RowRotateInstructionTests
    {
        private Day08RowRotateInstruction SubjectFactory(int index, int pixels)
             => new Day08RowRotateInstruction(index, pixels);

        private static string TestData1 =
@"....#.#
###....
.#.....";

        private static string TestData2 =
@"#....#.
###....
.#.....";

        private static string TestData3 =
@"#.#....
....###
.#.....";

        private static string TestData4 =
@"#.#....
###....
.....#.";

        public static IEnumerable<object[]> TestInput = new[]
        {
            new object[] { 0, 4, TestData1 },
            new object[] { 0, 5, TestData2 },
            new object[] { 1, 4, TestData3 },
            new object[] { 2, 4, TestData4 }
        };

        [Theory]
        [MemberData(nameof(TestInput))]
        public void Test(int wide, int tall, string expected)
        {
            var initial =
@"#.#....
###....
.#.....".ToDictionary();

            this.SubjectFactory(wide, tall).Apply(initial);

            initial.Should().Equal(expected.ToDictionary());
        }
    }
}