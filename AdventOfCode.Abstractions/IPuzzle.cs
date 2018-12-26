namespace AdventOfCode.Abstractions
{
    using System.Threading.Tasks;

    public interface IPuzzle
    {
        Task<string> PuzzleOne();

        Task<string> PuzzleTwo();
    }
}
