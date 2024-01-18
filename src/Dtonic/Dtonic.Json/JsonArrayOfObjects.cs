using Dtonic.Json.Base;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonArrayOfObjects<T> : JsonTypeBase<IEnumerable<T>?> where T : class, IDtonic, new()
{
    private JsonArrayOfObjects() { }

    public JsonArrayOfObjects(IEnumerable<T>? value) : base(value)
    {
    }

    public static JsonArrayOfObjects<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonArrayOfObjects<T>));

    public static implicit operator JsonArrayOfObjects<T>(Collection<T> items) => new((IEnumerable<T>)items);
    public static implicit operator JsonArrayOfObjects<T>(Array items) => new ((IEnumerable<T>?)items);
    public static implicit operator JsonArrayOfObjects<T>(ArrayList items) => new(items);
    public static implicit operator JsonArrayOfObjects<T>(List<T> items) => new((IEnumerable<T>?)items);
    public static implicit operator JsonArrayOfObjects<T>(Queue items) => new(items);
    public static implicit operator JsonArrayOfObjects<T>(ConcurrentQueue<T> items) => new((IEnumerable<T>?)items);
    public static implicit operator JsonArrayOfObjects<T>(Stack items) => new(items);
    public static implicit operator JsonArrayOfObjects<T>(ConcurrentStack<T> items) => new((IEnumerable<T>?)items);
    public static implicit operator JsonArrayOfObjects<T>(LinkedList<T> items) => new((IEnumerable<T>?)items);
}
