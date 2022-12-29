namespace AdventOfCode2016.Day23;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day23Puzzle : Puzzle
{
    private const string resource = "AdventOfCode2016.Day23.Input.txt";

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day23Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day23Solver.PuzzleTwo(input).ToString();
    }

    private async Task<IEnumerable<string>> GetInput()
    {
        return (await this.ReadResource(resource))
            .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }
}
