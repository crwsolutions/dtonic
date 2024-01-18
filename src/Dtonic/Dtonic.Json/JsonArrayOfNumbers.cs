using Dtonic.Json.Base;
using System.Diagnostics;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonArrayOfNumbers : JsonTypeBase<IEnumerable<decimal?>?>
{
    private JsonArrayOfNumbers() { }

    public JsonArrayOfNumbers(IEnumerable<decimal?>? value) : base(value)
    {
    }

    public static JsonArrayOfNumbers Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonArrayOfNumbers));

    //public static implicit operator JsonArrayOfNumbers(Collection<decimal> items) => new((IEnumerable<decimal>)items);
    public static implicit operator JsonArrayOfNumbers(Array items) => new((IEnumerable<decimal?>?)items);
    //public static implicit operator JsonArrayOfNumbers(ArrayList items) => new(items);
    //public static implicit operator JsonArrayOfNumbers(List<decimal> items) => new((IEnumerable<decimal>?)items);
    //public static implicit operator JsonArrayOfNumbers(Queue items) => new(items);
    //public static implicit operator JsonArrayOfNumbers(ConcurrentQueue<decimal> items) => new((IEnumerable<decimal>?)items);
    //public static implicit operator JsonArrayOfNumbers(Stack items) => new(items);
    //public static implicit operator JsonArrayOfNumbers(ConcurrentStack<decimal> items) => new((IEnumerable<decimal>?)items);
    //public static implicit operator JsonArrayOfNumbers(LinkedList<decimal> items) => new((IEnumerable<decimal>?)items);
}