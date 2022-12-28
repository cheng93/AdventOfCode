namespace AdventOfCode2016.Day22;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day22Puzzle : Puzzle
{
    private const string resource = "AdventOfCode2016.Day22.Input.txt";

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day22Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day22Solver.PuzzleTwo(input).ToString();
    }

    private async Task<IEnumerable<string>> GetInput()
    {
        return (await this.ReadResource(resource))
            .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    }
}
