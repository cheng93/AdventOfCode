namespace AdventOfCode2018.Tests.Day20
{
    using AdventOfCode2018.Day20;
    using Xunit;

    public class Day20SolverTests
    {
        private readonly Day20Solver subject = new Day20Solver();

        [Theory]
        [InlineData(23, "^ESSWWN(E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE)))$")]
        [InlineData(31, "^WSSEESWWWNW(S|NENNEEEENN(ESSSSW(NWSW|SSEN)|WSWWN(E|WWS(E|SS))))$")]
        public void PuzzleOne(int expected, string input)
        {
            var actual = this.subject.PuzzleOne(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(17, 8, "^ENNWSWW(NEWS|)SSSEEN(WNSE|)EE(SWEN|)NNN$")]
        [InlineData(7, 19, "^ESSWWN(E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE)))$")]
        [InlineData(2, 22, "^ESSWWN(E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE)))$")]
        [InlineData(33, 15, "^WSSEESWWWNW(S|NENNEEEENN(ESSSSW(NWSW|SSEN)|WSWWN(E|WWS(E|SS))))$")]
        public void PuzzleTwo(int expected, int doorsToPass, string input)
        {
            var actual = this.subject.PuzzleTwo(input, doorsToPass);

            Assert.Equal(expected, actual);
        }
    }
}