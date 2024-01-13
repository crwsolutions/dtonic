using Dtonic.Json.Base;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed class JsonArray<T> : JsonTypeBase<IEnumerable<T>?> 
{
    private JsonArray() { }

    public JsonArray(IEnumerable<T>? value) : base(value)
    {
    }

    public static JsonArray<T> Unspecified => new();

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(JsonArray<T>));
    }
}
