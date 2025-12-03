namespace AdventOfCode2025.Day03;

public class Day03Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day03Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day03Solver.PuzzleTwo(input).ToString();
    }

    private async Task<string> GetInput()
    {
        var resource = "AdventOfCode2025.Day03.Input.txt";
        return await this.ReadResource(resource);
    }
}