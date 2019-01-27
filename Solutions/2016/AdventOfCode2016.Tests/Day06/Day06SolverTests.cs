namespace AdventOfCode2016.Tests.Day06
{
    using System.Collections.Generic;
    using AdventOfCode2016.Day06;
    using Xunit;

    public class Day06SolverTests
    {
        private readonly Day06Solver subject = new Day06Solver();

        private static string TestData =
@"eedadn
drvtee
eandsr
raavrd
atevrs
tsrnev
sdttsa
rasrtv
nssdts
ntnada
svetve
tesnvt
vntsnd
vrdear
dvrsen
enarar";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { "easter", TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(string expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] { "advent", TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(string expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}