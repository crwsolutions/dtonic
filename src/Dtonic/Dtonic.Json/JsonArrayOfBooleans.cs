using Dtonic.Json.Base;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonArrayOfBooleans : JsonTypeBase<IEnumerable<bool?>?>
{
    private JsonArrayOfBooleans() { }

    public JsonArrayOfBooleans(IEnumerable<bool?>? value) : base(value)
    {
    }

    public static JsonArrayOfBooleans Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonArrayOfBooleans));

    //public static implicit operator JsonArrayOfBooleans(Collection<bool> items) => new((IEnumerable<bool>)items);
    //public static implicit operator JsonArrayOfBooleans(Array items) => new((IEnumerable<bool>?)items);
    //public static implicit operator JsonArrayOfBooleans(ArrayList items) => new(items);
    //public static implicit operator JsonArrayOfBooleans(List<bool> items) => new((IEnumerable<bool>?)items);
    //public static implicit operator JsonArrayOfBooleans(Queue items) => new(items);
    //public static implicit operator JsonArrayOfBooleans(ConcurrentQueue<bool> items) => new((IEnumerable<bool>?)items);
    //public static implicit operator JsonArrayOfBooleans(Stack items) => new(items);
    //public static implicit operator JsonArrayOfBooleans(ConcurrentStack<bool> items) => new((IEnumerable<bool>?)items);
    //public static implicit operator JsonArrayOfBooleans(LinkedList<bool> items) => new((IEnumerable<bool>?)items);
}