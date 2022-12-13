namespace AdventOfCode2022.Day13;

public class Day13Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day13Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day13Solver.PuzzleTwo(input).ToString();
    }

    private async Task<IEnumerable<string[]>> GetInput()
    {
        var resource = "AdventOfCode2022.Day13.Input.txt";
        return (await this.ReadResource(resource))
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => x.Split(Environment.NewLine));
    }
}