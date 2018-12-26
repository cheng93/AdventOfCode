namespace AdventOfCode.Abstractions
{
    public interface IPuzzleFactory
    {
        IPuzzle Create(int day);
    }
}