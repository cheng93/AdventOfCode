namespace AdventOfCode2021.Day07;

public class Day07Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day07Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day07Solver.PuzzleTwo(input).ToString();
    }

    private async Task<IEnumerable<int>> GetInput()
    {
        var resource = "AdventOfCode2021.Day07.Input.txt";
        return (await this.ReadResource(resource))
            .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
    }
}