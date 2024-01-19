using Dtonic.Json.Base;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonNumber : JsonTypeBase<decimal?>
{
    private JsonNumber() { }

    public JsonNumber(decimal? value) : base(value)
    {
    }

    public static JsonNumber Unspecified => new();

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(JsonNumber));
    }

    public override string Stringify() => IsNull ? "null" : Value.Value.ToString(CultureInfo.InvariantCulture);
    public override void Parse(ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            Value = null;
            return;
        }
        if (jsonReader.TokenType == JsonTokenType.Number)
        {
            Value = jsonReader.GetDecimal();
            return;
        }
        throw new Exception("Unknown type");
    }

    //numeric_type
    public static implicit operator JsonNumber(decimal value) => new(value);

    //integral_type
    public static implicit operator JsonNumber(sbyte value) => new(value);
    public static implicit operator JsonNumber(byte value) => new(value);
    public static implicit operator JsonNumber(short value) => new(value);
    public static implicit operator JsonNumber(ushort value) => new(value);
    public static implicit operator JsonNumber(int value) => new(value);
    public static implicit operator JsonNumber(uint value) => new(value);
    public static implicit operator JsonNumber(long value) => new(value);
    public static implicit operator JsonNumber(ulong value) => new(value);
    public static implicit operator JsonNumber(char value) => new(value);

    //floating_point_type
    public static implicit operator JsonNumber(float value) => new(value);
    public static implicit operator JsonNumber(double value) => new(value);
}
