using System.Collections.Generic;
using AdventOfCode2019.Day18;
using Xunit;

namespace AdventOfCode2019.Tests.Day18
{
    public class Day18SolverTests
    {
        private readonly Day18Solver subject = new Day18Solver();

        public static IEnumerable<object[]> PuzzleOneTestData = new[]
        {
            new object[]
            {
                8,
@"#########
#b.A.@.a#
#########"
            },
            new object[]
            {
                86,
@"########################
#f.D.E.e.C.b.A.@.a.B.c.#
######################.#
#d.....................#
########################"
            },
            new object[]
            {
                132,
@"########################
#...............b.C.D.f#
#.######################
#.....@.a.B.c.d.A.e.F.g#
########################"
            },
            new object[]
            {
                136,
@"#################
#i.G..c...e..H.p#
########.########
#j.A..b...f..D.o#
########@########
#k.E..a...g..B.n#
########.########
#l.F..d...h..C.m#
#################"
            },
            new object[]
            {
                81,
@"########################
#@..............ac.GI.b#
###d#e#f################
###A#B#C################
###g#h#i################
########################"
            },
            new object[]
            {
                36,
@"###########
#a...#...b#
####...####
####.@.####
####...####
#c...#...d#
###########"
            },
        };

        [Theory]
        [MemberData(nameof(PuzzleOneTestData))]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> PuzzleTwoTestData = new[]
        {
            new object[]
            {
                8,
@"#######
#a.#Cd#
##@#@##
#######
##@#@##
#cB#.b#
#######"
            },
            new object[]
            {
                24,
@"###############
#d.ABC.#.....a#
######@#@######
###############
######@#@######
#b.....#.....c#
###############"
            },
            new object[]
            {
                32,
@"#############
#DcBa.#.GhKl#
#.###@#@#I###
#e#d#####j#k#
###C#@#@###J#
#fEbA.#.FgHi#
#############"
            },
            new object[]
            {
                72,
@"#############
#g#f.D#..h#l#
#F###e#E###.#
#dCba@#@BcIJ#
#############
#nK.L@#@G...#
#M###N#H###.#
#o#m..#i#jk.#
#############"
            },
        };

        [Theory]
        [MemberData(nameof(PuzzleTwoTestData))]
        public void PuzzleTwo(int expected, string input)
        {
            var actual = this.subject.PuzzleTwo(input);

            Assert.Equal(expected, actual);
        }
    }
}