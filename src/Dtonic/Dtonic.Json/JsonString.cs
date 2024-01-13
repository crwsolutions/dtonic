using Dtonic.Json.Base;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonString : JsonTypeBase<string?>
{
    private JsonString() { }

    public JsonString(string? value) : base(value)
    {
    }

    public static JsonString Unspecified => new();

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(JsonString));
    }
}
