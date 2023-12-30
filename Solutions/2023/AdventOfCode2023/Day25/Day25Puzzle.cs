namespace AdventOfCode2023.Day25;

public class Day25Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day25Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        return await Task.FromResult("Year 2023 Completed");
    }

    private async Task<string> GetInput()
    {
        var resource = "AdventOfCode2023.Day25.Input.txt";
        return await this.ReadResource(resource);
    }
}