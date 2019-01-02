namespace AdventOfCode2018.Day09
{
    public class Day09Solver
    {
        public long PuzzleOne(string input)
        {
            //9 players; last marble is worth 25 points
            var splits = input.Split(' ');
            var players = int.Parse(splits[0]);
            var length = int.Parse(splits[6]);

            return new Day09Scorer().GetHighestScore(players, length);
        }

        public long PuzzleTwo(string input)
        {
            //9 players; last marble is worth 25 points
            var splits = input.Split(' ');
            var players = int.Parse(splits[0]);
            var length = int.Parse(splits[6]);

            return new Day09ImprovedScorer().GetHighestScore(players, length * 100);
        }
    }
}