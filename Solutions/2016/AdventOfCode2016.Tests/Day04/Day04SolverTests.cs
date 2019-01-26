namespace AdventOfCode2016.Tests.Day04
{
    using System.Collections.Generic;
    using AdventOfCode2016.Day04;
    using Xunit;

    public class Day04SolverTests
    {
        private readonly Day04Solver subject = new Day04Solver();

        private static string TestData =
@"aaaaa-bbb-z-y-x-123[abxyz]
a-b-c-d-e-f-g-h-987[abcde]
not-a-real-room-404[oarel]
totally-real-room-200[decoy]";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { 1514, TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }
    }
}