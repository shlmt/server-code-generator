namespace ServerGenerator
{
    internal abstract class Model : IGenerate<bool>
    {
        public required string Name { get; init; }
        public required Property[] Properties { get; init; }

        public abstract bool Generate();
    }
}