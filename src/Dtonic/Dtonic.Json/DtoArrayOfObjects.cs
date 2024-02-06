using Dtonic.Dto.Base;
using Dtonic.Dto.Exceptions;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoArrayOfObjects<T> : DtoValueBase<IEnumerable<T?>?> where T : class, IDtonic, new()
{
    private DtoArrayOfObjects() { }

    public DtoArrayOfObjects(IEnumerable<T>? value) : base(value)
    {
    }

    public static DtoArrayOfObjects<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoArrayOfObjects<T>));
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
            if (item == null)
            {
                bob.Append("null");
            }
            else if (item is IDtonic dto)
            {
                bob.Append(dto.Stringify());
            }
            else
            {
                throw DtoDoesNotImplementIDtoSerializableException.Create("?", Value.GetType());
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
        var lst = new List<T?>();
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
                    lst.Add(default);
                }
                else if (jsonReader.TokenType == JsonTokenType.StartObject)
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

    public static implicit operator DtoArrayOfObjects<T>(Collection<T> items) => new((IEnumerable<T>)items);
    public static implicit operator DtoArrayOfObjects<T>(Array items) => new((IEnumerable<T>?)items);
    public static implicit operator DtoArrayOfObjects<T>(ArrayList items) => new(items);
    public static implicit operator DtoArrayOfObjects<T>(List<T> items) => new((IEnumerable<T>?)items);
    public static implicit operator DtoArrayOfObjects<T>(Queue items) => new(items);
    public static implicit operator DtoArrayOfObjects<T>(ConcurrentQueue<T> items) => new((IEnumerable<T>?)items);
    public static implicit operator DtoArrayOfObjects<T>(Stack items) => new(items);
    public static implicit operator DtoArrayOfObjects<T>(ConcurrentStack<T> items) => new((IEnumerable<T>?)items);
    public static implicit operator DtoArrayOfObjects<T>(LinkedList<T> items) => new((IEnumerable<T>?)items);
}
