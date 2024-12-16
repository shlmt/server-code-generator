namespace ServerGenerator
{
    internal abstract class Server : IGenerate<bool>
    {
        public required Language Language { get; init; }
        public required Database Database { get; init; }
        public required string DataBaseURL { get; init; }
        public bool HasAuth { get; init; } = false;
        public required Model[] Models { get; init; }

        public abstract bool Generate();
    }
}
