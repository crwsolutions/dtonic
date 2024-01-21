using Dtonic.Json.Base;
using Dtonic.Json.Exceptions;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

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
            if (Value is IDtonic dto)
            {
                bob.Append(dto.Stringify());
            }
            else
            {
                throw DoesNotImplementIJsonSerializableException.Create("?", Value.GetType());
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
        var lst = new List<T>();
        if (jsonReader.TokenType == JsonTokenType.StartArray)
        {
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }
                if (jsonReader.TokenType == JsonTokenType.StartObject)
                {
                    var t = new T();
                    if (t is IDtonic deserializable)
                    {
                        deserializable.Parse(ref jsonReader);
                        lst.Add(t);
                        continue;
                    }
                    throw new Exception("Unknown type");
                }
            }
        }
        Value = lst;
    }

    public static implicit operator JsonArrayOfObjects<T>(Collection<T> items) => new((IEnumerable<T>)items);
    public static implicit operator JsonArrayOfObjects<T>(Array items) => new((IEnumerable<T>?)items);
    public static implicit operator JsonArrayOfObjects<T>(ArrayList items) => new(items);
    public static implicit operator JsonArrayOfObjects<T>(List<T> items) => new((IEnumerable<T>?)items);
    public static implicit operator JsonArrayOfObjects<T>(Queue items) => new(items);
    public static implicit operator JsonArrayOfObjects<T>(ConcurrentQueue<T> items) => new((IEnumerable<T>?)items);
    public static implicit operator JsonArrayOfObjects<T>(Stack items) => new(items);
    public static implicit operator JsonArrayOfObjects<T>(ConcurrentStack<T> items) => new((IEnumerable<T>?)items);
    public static implicit operator JsonArrayOfObjects<T>(LinkedList<T> items) => new((IEnumerable<T>?)items);
}
