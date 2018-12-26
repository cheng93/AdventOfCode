
namespace AdventOfCode.Abstractions
{
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;

    public abstract class Puzzle : IPuzzle
    {
        public abstract Task<string> PuzzleOne();

        public abstract Task<string> PuzzleTwo();

        protected async Task<string> ReadResource(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}