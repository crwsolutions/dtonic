using Dtonic.Json.Base;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

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
                bob.Append(item.Value.ToString().ToLower());
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
        var lst = new List<bool?>();
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
                else if (jsonReader.TokenType == JsonTokenType.True)
                {
                    lst.Add(true);
                }
                else if (jsonReader.TokenType == JsonTokenType.False)
                {
                    lst.Add(false);
                }
            }
        }

        Value = lst;
    }

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