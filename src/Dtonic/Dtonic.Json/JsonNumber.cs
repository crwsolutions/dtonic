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
}
