namespace AdventOfCode2016.Tests.Day08
{
    using System.Collections.Generic;
    using AdventOfCode2016.Day08;
    using FluentAssertions;
    using Xunit;

    public class Day08ColumnRotateInstructionTests
    {
        private Day08ColumnRotateInstruction SubjectFactory(int index, int pixels)
             => new Day08ColumnRotateInstruction(index, pixels);

        private static string TestData1 =
@"#.#....
###....
.#.....";

        private static string TestData2 =
@".##....
###....
#......";

        private static string TestData3 =
@"###....
###....
.......";

        private static string TestData4 =
@"##.....
###....
..#....";

        private static string TestData5 =
@"###....
##.....
..#....";

        public static IEnumerable<object[]> TestInput = new[]
        {
            new object[] { 1, 1, TestData1 },
            new object[] { 0, 1, TestData2 },
            new object[] { 3, 1, TestData3 },
            new object[] { 2, 1, TestData4 },
            new object[] { 2, 2, TestData5 }
        };

        [Theory]
        [MemberData(nameof(TestInput))]
        public void Test(int wide, int tall, string expected)
        {
            var initial =
@"###....
###....
.......".ToDictionary();

            this.SubjectFactory(wide, tall).Apply(initial);

            initial.Should().Equal(expected.ToDictionary());
        }
    }
}