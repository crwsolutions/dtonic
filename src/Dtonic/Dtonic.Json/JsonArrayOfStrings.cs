using Dtonic.Json.Base;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

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
                bob.Append('"');
                bob.Append(item);
                bob.Append('"');
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
        var lst = new List<string?>();
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
                else if (jsonReader.TokenType == JsonTokenType.String)
                {
                    lst.Add(jsonReader.GetString());
                }
            }
        }

        Value = lst;
    }

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