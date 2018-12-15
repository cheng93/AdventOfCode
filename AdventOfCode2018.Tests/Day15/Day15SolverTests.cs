namespace AdventOfCode2018.Tests.Day15
{
    using System.Collections.Generic;
    using AdventOfCode2018.Day15;
    using Xunit;

    public class Day15SolverTests
    {
        private readonly Day15Solver subject = new Day15Solver();

        private static string TestData1 =
@"#######
#.G...#
#...EG#
#.#.#G#
#..G#E#
#.....#
#######";

        private static string TestData2 =
@"#######
#G..#E#
#E#E.E#
#G.##.#
#...#E#
#...E.#
#######";

        private static string TestData3 =
@"#######
#E..EG#
#.#G.E#
#E.##E#
#G..#.#
#..E#.#
#######";

        private static string TestData4 =
@"#######
#E.G#.#
#.#G..#
#G.#.G#
#G..#.#
#...E.#
#######";

        private static string TestData5 =
@"#######
#.E...#
#.#..G#
#.###.#
#E#G#G#
#...#G#
#######";

        private static string TestData6 =
@"#########
#G......#
#.E.#...#
#..##..G#
#...##..#
#...#...#
#.G...G.#
#.....G.#
#########";

        public static IEnumerable<object[]> PuzzleOneData = new[]
        {
            new object[] {27730, TestData1},
            new object[] {36334, TestData2},
            new object[] {39514, TestData3},
            new object[] {27755, TestData4},
            new object[] {28944, TestData5},
            new object[] {18740, TestData6},
        };

        [Theory]
        [MemberData(nameof(PuzzleOneData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoData = new[]
        {
            new object[] {4988, TestData1},
            new object[] {31284, TestData3},
            new object[] {3478, TestData4},
            new object[] {6474, TestData5},
            new object[] {1140, TestData6},
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