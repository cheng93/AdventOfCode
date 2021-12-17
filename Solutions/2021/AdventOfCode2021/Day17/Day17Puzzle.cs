namespace AdventOfCode2021.Day17;

public class Day17Puzzle : Puzzle
{
    private const string Input = "target area: x=240..292, y=-90..-57";

    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day17Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day17Solver.PuzzleTwo(input).ToString();
    }

    private async Task<string> GetInput()
        => await Task.FromResult(Input);
}