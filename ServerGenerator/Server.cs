namespace ServerGenerator
{
    internal abstract class Server : IGenerate<bool>
    {
        public required string Name { get; init; }
        public required string RootDirectory { get; init; }
        public required string Language { get; init; }
        public required string Database { get; init; }
        public required string DataBaseURL { get; init; }
        public bool HasAuth { get; init; } = false;
        public required Model[] Models { get; init; }

        public abstract bool Generate();
    }
}
