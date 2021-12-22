namespace AdventOfCode2021.Day21;

public class Day21Puzzle : Puzzle
{
    private static int[] Input = new[] { 8, 9 };
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day21Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day21Solver.PuzzleTwo(input).ToString();
    }

    private async Task<int[]> GetInput()
    {
        return await Task.FromResult(Input);
    }
}