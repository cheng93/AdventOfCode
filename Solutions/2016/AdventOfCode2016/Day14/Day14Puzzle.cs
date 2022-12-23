namespace AdventOfCode2016.Day14;

using System.Threading.Tasks;
using AdventOfCode.Abstractions;

public class Day14Puzzle : Puzzle
{
    private const string Input = "ihaygndm";

    public async override Task<string> PuzzleOne()
    {
        var input = await this.GetInput();

        return Day14Solver.PuzzleOne(input).ToString();
    }

    public async override Task<string> PuzzleTwo()
    {
        var input = await this.GetInput();

        return Day14Solver.PuzzleTwo(input).ToString();
    }

    private Task<string> GetInput() => Task.FromResult(Input);
}
