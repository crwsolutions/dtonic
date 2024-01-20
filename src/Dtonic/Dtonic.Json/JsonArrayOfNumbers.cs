using Dtonic.Json.Base;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonArrayOfNumbers : JsonTypeBase<IEnumerable<decimal?>?>
{
    public JsonArrayOfNumbers() { }

    public JsonArrayOfNumbers(IEnumerable<decimal?>? value) : base(value)
    {
    }

    public static JsonArrayOfNumbers Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonArrayOfNumbers));

    public override string Stringify()
    {
        if (IsNull)
        {
            return "null";
        }

        var first = true;
        var bob = new StringBuilder();
        bob.Append('[');
        foreach (var item in Value)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                bob.Append(',');
            }
            if (item is null)
            {
                bob.Append("null");
            }
            else
            {
                bob.Append(item.Value.ToString(CultureInfo.InvariantCulture));
            }
        }

        bob.Append(']');
        return bob.ToString();
    }
    public override void Parse(ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            Value = null;
            return;
        }

        var lst = new List<decimal?>();
        if (jsonReader.TokenType == JsonTokenType.StartArray)
        {
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                if (jsonReader.TokenType == JsonTokenType.Null)
                {
                    lst.Add(null);
                }
                else if (jsonReader.TokenType == JsonTokenType.Number)
                {
                    lst.Add(jsonReader.GetDecimal());
                }
            }
        }

        Value = lst;
    }

    //public static implicit operator JsonArrayOfNumbers(Collection<decimal> items) => new((IEnumerable<decimal>)items);
    public static implicit operator JsonArrayOfNumbers(decimal?[] items) => new(items.AsEnumerable());
    public static implicit operator JsonArrayOfNumbers(decimal[] items) => new(Array.ConvertAll(items, number => (decimal?)number).AsEnumerable());
    //public static implicit operator JsonArrayOfNumbers(ArrayList items) => new(items);
    //public static implicit operator JsonArrayOfNumbers(List<decimal> items) => new((IEnumerable<decimal>?)items);
    //public static implicit operator JsonArrayOfNumbers(Queue items) => new(items);
    //public static implicit operator JsonArrayOfNumbers(ConcurrentQueue<decimal> items) => new((IEnumerable<decimal>?)items);
    //public static implicit operator JsonArrayOfNumbers(Stack items) => new(items);
    //public static implicit operator JsonArrayOfNumbers(ConcurrentStack<decimal> items) => new((IEnumerable<decimal>?)items);
    //public static implicit operator JsonArrayOfNumbers(LinkedList<decimal> items) => new((IEnumerable<decimal>?)items);
}