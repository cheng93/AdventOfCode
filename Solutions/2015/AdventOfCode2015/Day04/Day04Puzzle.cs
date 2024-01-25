namespace AdventOfCode2015.Day04;

public class Day04Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day04Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day04Solver.PuzzleTwo(input).ToString();
    }

    private async Task<string> GetInput() => await Task.FromResult("iwrupvqb");
}