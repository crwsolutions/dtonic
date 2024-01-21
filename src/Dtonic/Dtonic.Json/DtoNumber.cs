using Dtonic.Dto.Base;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoNumber : DtoValueBase<decimal?>
{
    private DtoNumber() { }

    public DtoNumber(decimal? value) : base(value)
    {
    }

    public static DtoNumber Unspecified => new();

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(DtoNumber));
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
    public static implicit operator DtoNumber(decimal value) => new(value);

    //integral_type
    public static implicit operator DtoNumber(sbyte value) => new(value);
    public static implicit operator DtoNumber(byte value) => new(value);
    public static implicit operator DtoNumber(short value) => new(value);
    public static implicit operator DtoNumber(ushort value) => new(value);
    public static implicit operator DtoNumber(int value) => new(value);
    public static implicit operator DtoNumber(uint value) => new(value);
    public static implicit operator DtoNumber(long value) => new(value);
    public static implicit operator DtoNumber(ulong value) => new(value);
    public static implicit operator DtoNumber(char value) => new(value);

    //floating_point_type
    public static implicit operator DtoNumber(float value) => new(value);
    public static implicit operator DtoNumber(double value) => new(value);
}
