namespace AdventOfCode2022.Day14;

public class Day14Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day14Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day14Solver.PuzzleTwo(input).ToString();
    }

    private async Task<IEnumerable<string>> GetInput()
    {
        var resource = "AdventOfCode2022.Day14.Input.txt";
        return (await this.ReadResource(resource))
            .Split(Environment.NewLine);
    }
}