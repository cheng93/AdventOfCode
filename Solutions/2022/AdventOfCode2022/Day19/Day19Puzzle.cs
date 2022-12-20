namespace AdventOfCode2022.Day19;

public class Day19Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day19Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day19Solver.PuzzleTwo(input).ToString();
    }

    private async Task<IEnumerable<string>> GetInput()
    {
        var resource = "AdventOfCode2022.Day19.Input.txt";
        return (await this.ReadResource(resource)).Split(Environment.NewLine);
    }
}