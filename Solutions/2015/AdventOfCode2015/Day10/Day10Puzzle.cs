namespace AdventOfCode2015.Day10;

public class Day10Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day10Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day10Solver.PuzzleTwo(input).ToString();
    }

    private async Task<string> GetInput() => await Task.FromResult("3113322113");
}