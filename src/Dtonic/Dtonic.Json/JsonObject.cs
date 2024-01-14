using Dtonic.Json.Base;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonObject<T> : JsonTypeBase<T> where T : class
{
    private JsonObject() { }

    public JsonObject(T? value) : base(value)
    {
    }

    public static JsonObject<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonObject<T>));

    public static implicit operator JsonObject<T>(T value)
    {
        return new(value);
    }
}