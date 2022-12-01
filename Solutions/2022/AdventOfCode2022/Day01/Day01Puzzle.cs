namespace AdventOfCode2022.Day01;

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

    private async Task<IEnumerable<string>> GetInput()
    {
        var resource = "AdventOfCode2022.Day01.Input.txt";
        return (await this.ReadResource(resource))
            .Split($"{Environment.NewLine}{Environment.NewLine}");
    }
}