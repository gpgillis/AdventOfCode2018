namespace AdventOfCode2018
{
    using System.Threading.Tasks;

    public interface IPuzzle
    {
        string PuzzleName { get; }

        Task<string> PuzzleA();

        Task<string> PuzzleB();
    }
}
