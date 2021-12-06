namespace AdventOfCode2021.Day06;

public class Day06Puzzle : Puzzle
{
    public override async Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day06Solver.PuzzleOne(input).ToString();
    }

    public override async Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day06Solver.PuzzleTwo(input).ToString();
    }

    private async Task<IEnumerable<int>> GetInput()
    {
        var resource = "AdventOfCode2021.Day06.Input.txt";
        return (await this.ReadResource(resource))
            .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);
    }
}