namespace ServerGenerator.nodejs
{
    internal class NodeProperty : Property
    {
        public override string Generate()
        {
            bool isNumber = Type == DataType.Number
                            || Type == DataType.Double
                            || Type == DataType.BigInt
                            || Type == DataType.Decimal128
                            || Type == DataType.Int32;
            bool isArray = Type.ToString().EndsWith("s", StringComparison.OrdinalIgnoreCase);

            return $"\t\t{Name}:" +
                "{\r\n" +
                $"\t\t\ttype: {(isArray ? "[" + Type.ToString().Substring(0, Type.ToString().Length - 1) + "]" : Type)},\r\n" +
                (IsRequired ? "\t\t\trequire: true,\r\n" : "") +
                (DefaultValue != null ? $"\t\t\tdefault: {DefaultValue},\r\n" : "") +
                (IsUnique ? "\t\t\tunique: true,\r\n" : "") +
                (IsImmutable ? "\t\t\timmutable: true,\r\n" : "") +
                (Enum != null && Enum.Length != 0 ? $"\t\t\tenum: [{string.Join(", ", Enum.Select(e => $"\"{e}\""))}],\r\n" : "") +
                (Min != null && Type == DataType.String ? $"            minLength: {Min},\r\n" : "") +
                (Max != null && Type == DataType.String ? $"\t\t\tmaxLength: {Max},\r\n" : "") +
                (Min != null && isNumber ? $"\t\t\tmin: {Min},\r\n" : "") +
                (Max != null && isNumber ? $"\t\t\tmax: {Max},\r\n" : "") +
                (Type == DataType.String && IsLowerCase ? "\t\t\tlowercase: true,\r\n" : "") +
                (Type == DataType.String && IsUpperCase ? "\t\t\tuppercase: true,\r\n" : "") +
                (Type == DataType.String && IsTrim ? "\t\t\ttrim: true,\r\n" : "") +
                (Type == DataType.ObjectId && Ref != null ? $"\t\t\tref: \"{Utils.CapitalizeFirstLetter(Ref)}\",\r\n" : "") +
                "\t\t},\r\n";
        }
    }
}
