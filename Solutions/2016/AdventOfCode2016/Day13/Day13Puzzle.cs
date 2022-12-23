namespace AdventOfCode2016.Day13;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day13Puzzle : Puzzle
{
    private const int Input = 1362;

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day13Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day13Solver.PuzzleTwo(input).ToString();
    }

    private Task<int> GetInput() => Task.FromResult(Input);
}
