using System.Collections.Generic;
using System.Drawing;
using AdventOfCode2019.Day10;
using Xunit;

namespace AdventOfCode2019.Tests.Day10
{
    public class Day10SolverTests
    {
        private readonly Day10Solver subject = new Day10Solver();

        public static IEnumerable<object[]> PuzzleOneTestData = new[]
        {
            new object[]
            {
                (new Point(3,4), 8),
@".#..#
.....
#####
....#
...##"
            },
            new object[]
            {
                (new Point(5,8), 33),
@"......#.#.
#..#.#....
..#######.
.#.#.###..
.#..#.....
..#....#.#
#..#....#.
.##.#..###
##...#..#.
.#....####"
            },
            new object[]
            {
                (new Point(1,2), 35),
@"#.#...#.#.
.###....#.
.#....#...
##.#.#.#.#
....#.#.#.
.##..###.#
..#...##..
..##....##
......#...
.####.###."
            },
            new object[]
            {
                (new Point(6,3), 41),
@".#..#..###
####.###.#
....###.#.
..###.##.#
##.##.#.#.
....###..#
..#.#..#.#
#..#.#.###
.##...##.#
.....#.#.."
            },
            new object[]
            {
                (new Point(11,13), 210),
@".#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##"
            }
        };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne((Point point, int count) expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(11, 12, 1)]
        [InlineData(12, 1, 2)]
        [InlineData(12, 2, 3)]
        [InlineData(12, 8, 10)]
        [InlineData(16, 0, 20)]
        [InlineData(16, 9, 50)]
        [InlineData(10, 16, 100)]
        [InlineData(9, 6, 199)]
        [InlineData(8, 2, 200)]
        [InlineData(10, 9, 201)]
        [InlineData(11, 1, 299)]
        public void PuzzleTwo(int x, int y, int nth)
        {
            var input =

@".#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##";

            var actual = this.subject.PuzzleTwo(input, new Point(11, 13), nth);

            Assert.Equal(new Point(x, y), actual);
        }
    }
}