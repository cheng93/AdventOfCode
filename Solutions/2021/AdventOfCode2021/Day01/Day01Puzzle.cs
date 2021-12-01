namespace AdventOfCode2021.Day01;

public class Day01Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day01Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day01Solver.PuzzleTwo(input).ToString();
    }

    private async Task<IEnumerable<int>> GetInput()
    {
        var resource = "AdventOfCode2021.Day01.Input.txt";
        return (await this.ReadResource(resource))
            .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x));
    }
}