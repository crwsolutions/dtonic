using Dtonic.Json.Base;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonDictionary<T> : JsonTypeBase<IDictionary<string, T>>
{
    private JsonDictionary() { }

    public JsonDictionary(IDictionary<string, T>? value) : base(value)
    {
    }

    public static JsonDictionary<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonDictionary<T>));

    public static implicit operator JsonDictionary<T>(Dictionary<string, T>? items) => new((IDictionary<string, T>?)items);
}
