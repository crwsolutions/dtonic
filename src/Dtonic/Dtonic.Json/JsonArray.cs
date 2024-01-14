using Dtonic.Json.Base;
using Dtonic.Json.Extensions;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonArray<T> : JsonTypeBase<IEnumerable>
{
    private JsonArray() { }

    public JsonArray(IEnumerable<T> value) : base(value)
    {
    }

    public static JsonArray<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonArray<T>));

    public static implicit operator JsonArray<T>(Collection<T> items) => items.ToJsonArray();
    public static implicit operator JsonArray<T>(Array items) => new(items);
    public static implicit operator JsonArray<T>(ArrayList items) => new(items);
    public static implicit operator JsonArray<T>(List<T> items) => items.ToJsonArray();
    public static implicit operator JsonArray<T>(Queue items) => new(items);
    public static implicit operator JsonArray<T>(ConcurrentQueue<T> items) => items.ToJsonArray();
    public static implicit operator JsonArray<T>(Stack items) => new(items);
    public static implicit operator JsonArray<T>(ConcurrentStack<T> items) => items.ToJsonArray();
    public static implicit operator JsonArray<T>(LinkedList<T> items) => items.ToJsonArray();
}
