namespace AdventOfCode2016.Day25;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day25Puzzle : Puzzle
{
    private const string resource = "AdventOfCode2016.Day25.Input.txt";

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day25Solver.PuzzleOne(input).ToString();
    }

    public override Task<string> PuzzleTwo()
    {
        return Task.FromResult("Year 2016 Completed");
    }

    private async Task<IEnumerable<string>> GetInput()
    {
        return (await this.ReadResource(resource))
            .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }
}
