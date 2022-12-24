namespace AdventOfCode2016.Day16;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day16Puzzle : Puzzle
{
    private const string Input = "10001110011110000";

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day16Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day16Solver.PuzzleTwo(input).ToString();
    }

    private Task<string> GetInput() => Task.FromResult(Input);
}
