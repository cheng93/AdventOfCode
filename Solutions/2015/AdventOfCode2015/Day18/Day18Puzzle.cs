namespace AdventOfCode2015.Day18;

public class Day18Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day18Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day18Solver.PuzzleTwo(input).ToString();
    }

    private async Task<string> GetInput()
    {
        var resource = "AdventOfCode2015.Day18.Input.txt";
        return await this.ReadResource(resource);
    }
}