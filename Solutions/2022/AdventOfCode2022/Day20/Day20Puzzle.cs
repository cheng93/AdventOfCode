namespace AdventOfCode2022.Day20;

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

    private async Task<IEnumerable<int>> GetInput()
    {
        var resource = "AdventOfCode2022.Day20.Input.txt";
        return (await this.ReadResource(resource))
            .Split(Environment.NewLine)
            .Select(int.Parse);
    }
}