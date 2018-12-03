namespace AdventOfCode2018
{
    using System.Threading.Tasks;

    public interface IPuzzle
    {
        Task<string> PuzzleOne();

        Task<string> PuzzleTwo();
    }
}
