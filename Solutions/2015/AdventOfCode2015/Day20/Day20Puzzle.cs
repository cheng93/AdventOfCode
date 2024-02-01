namespace AdventOfCode2015.Day20;

public class Day20Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day20Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day20Solver.PuzzleTwo(input).ToString();
    }

    private async Task<string> GetInput() => await Task.FromResult("33100000");
}