namespace AdventOfCode2016.Day24;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day24Puzzle : Puzzle
{
    private const string resource = "AdventOfCode2016.Day24.Input.txt";

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day24Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day24Solver.PuzzleTwo(input).ToString();
    }

    private async Task<string> GetInput()
    {
        return (await this.ReadResource(resource));
    }
}
