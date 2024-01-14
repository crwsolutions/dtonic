using Dtonic.Json.Base;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonNumber : JsonTypeBase<decimal?>
{
    private JsonNumber() { }

    public JsonNumber(decimal? value) : base(value)
    {
    }

    private static readonly JsonNumber _unspecified = new();
    public static JsonNumber Unspecified => _unspecified;

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(JsonNumber));
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
