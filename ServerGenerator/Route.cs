namespace ServerGenerator
{
    internal abstract class Route : IGenerate<bool>
    {
        public required string Name { get; init; }

        public abstract bool Generate();
    }
}
