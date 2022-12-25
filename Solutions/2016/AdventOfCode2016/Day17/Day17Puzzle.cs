namespace AdventOfCode2016.Day17;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day17Puzzle : Puzzle
{
    private const string Input = "qzthpkfp";

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day17Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day17Solver.PuzzleTwo(input).ToString();
    }

    private Task<string> GetInput() => Task.FromResult(Input);
}
