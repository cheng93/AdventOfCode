namespace AdventOfCode2017.Tests.Day19
{
    using System.Collections.Generic;
    using AdventOfCode2017.Day19;
    using Xunit;

    public class Day19SolverTests
    {
        private Day19Solver subject = new Day19Solver();

        private static string TestData =
@"     |          
     |  +--+    
     A  |  C    
 F---|----E|--+ 
     |  |  |  D 
     +B-+  +--+ ";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] { "ABCDEF", TestData }
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
            new object[] { 38, TestData }
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoData))]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}