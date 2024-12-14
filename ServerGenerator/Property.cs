namespace ServerGenerator
{
    internal abstract class Property : IGenerate<string>
    {
        public required string Name { get; init; }
        public required DataType Type { get; init; }
        public bool IsRequired { get; init; } = false;
        public bool IsUnique { get; init; } = false;
        public bool IsLowerCase { get; init; } = false;
        public bool IsUpperCase { get; init; } = false;
        public bool IsTrim { get; init; } = false;
        public bool IsImmutable { get; init; } = false;
        public string? DefaultValue { get; init; }
        public string[]? Enum { get; init; }
        public int? Max { get; init; }
        public int? Min { get; init; }
        public string? Ref { get; init; }

        public abstract string Generate();
    }
}