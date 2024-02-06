using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithArrayofObjects<T> : DtoValueBase<IDictionary<string, IEnumerable<T?>?>> where T : IDtonic, new()
{
    private DtoDictionaryWithArrayofObjects() { }

    public DtoDictionaryWithArrayofObjects(IDictionary<string, IEnumerable<T?>?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithArrayofObjects<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithArrayofObjects<T>));

    public override string Stringify()
    {
        if (IsNull)
        {
            return NULL;
        }

        var bob = new StringifyDictionaryBuilder();
        foreach (var item in Value)
        {
            if (item.Value is null)
            {
                bob.Add(item.Key, NULL);
            }
            else
            {
                var arrayBob = new StringifyArrayBuilder();
                foreach (var arrayItem in item.Value)
                {
                    arrayBob.Add(arrayItem is null ? NULL : arrayItem.Stringify());
                }
                bob.Add(item.Key, arrayBob.ToString());
            }
        }
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
        var dictionary = new Dictionary<string, IEnumerable<T?>?>();
        if (jsonReader.TokenType == JsonTokenType.StartArray)
        {
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }
                if (jsonReader.TokenType == JsonTokenType.PropertyName)
                {
                    var key = jsonReader.GetString()!;
                    jsonReader.Read();
                    if (jsonReader.TokenType == JsonTokenType.Null)
                    {
                        dictionary.Add(key, default);
                    }
                    if (jsonReader.TokenType == JsonTokenType.StartArray)
                    {
                        var lst = new List<T?>();
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
                                t.Parse(ref jsonReader);
                                lst.Add(t);
                            }
                        }
                        dictionary.Add(key, lst);
                    }
                }
            }
        }
        Value = dictionary;
    }

    public static implicit operator DtoDictionaryWithArrayofObjects<T>(Dictionary<string, IEnumerable<T?>?>? items) => new((IDictionary<string, IEnumerable<T?>?>?)items);
}
