using Dtonic.Json.Base;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonBoolean : JsonTypeBase<bool?>
{
    private JsonBoolean() { }

    public JsonBoolean(bool? value) : base(value)
    {
    }

    public static JsonBoolean Unspecified => new();

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(JsonBoolean));
    }
}