namespace ServerGenerator
{
    internal abstract class Controller : IGenerate<bool>
    {
        public required string Name { get; init; }
        public required Model Model { get; init; }

        public abstract bool Generate();
    }
}
