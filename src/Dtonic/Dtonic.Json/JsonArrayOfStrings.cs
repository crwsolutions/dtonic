using Dtonic.Json.Base;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonArrayOfStrings : JsonTypeBase<IEnumerable<string?>?>
{
    private JsonArrayOfStrings() { }

    public JsonArrayOfStrings(IEnumerable<string?>? value) : base(value)
    {
    }

    public static JsonArrayOfStrings Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonArrayOfStrings));

    //public static implicit operator JsonArrayOfStrings(Collection<string> items) => new((IEnumerable<string>)items);
    //public static implicit operator JsonArrayOfStrings(Array items) => new((IEnumerable<string>?)items);
    //public static implicit operator JsonArrayOfStrings(ArrayList items) => new(items);
    //public static implicit operator JsonArrayOfStrings(List<string> items) => new((IEnumerable<string>?)items);
    //public static implicit operator JsonArrayOfStrings(Queue items) => new(items);
    //public static implicit operator JsonArrayOfStrings(ConcurrentQueue<string> items) => new((IEnumerable<string>?)items);
    //public static implicit operator JsonArrayOfStrings(Stack items) => new(items);
    //public static implicit operator JsonArrayOfStrings(ConcurrentStack<string> items) => new((IEnumerable<string>?)items);
    //public static implicit operator JsonArrayOfStrings(LinkedList<string> items) => new((IEnumerable<string>?)items);
}