using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithObjects<T> : DtoValueBase<IDictionary<string, T?>> where T : IDtonic, new()
{
    private DtoDictionaryWithObjects() { }

    public DtoDictionaryWithObjects(IDictionary<string, T?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithObjects<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithObjects<T>));

    public override string Stringify()
    {
        if (IsNull)
        {
            return NULL;
        }
        var bob = new StringifyDictionaryBuilder();
        foreach (var item in Value)
        {
            bob.Add(item.Key, item.Value is null ? NULL : item.Value.Stringify());
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
        var dictionary = new Dictionary<string, T?>();
        if (jsonReader.TokenType == JsonTokenType.StartObject)
        {
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonTokenType.EndObject)
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
                    else if (jsonReader.TokenType == JsonTokenType.StartObject)
                    {
                        var t = new T();
                        t.Parse(ref jsonReader);
                        dictionary.Add(key, t);
                    }
                }
            }
        }
        Value = dictionary;
    }

    public static implicit operator DtoDictionaryWithObjects<T>(Dictionary<string, T?>? items) => new((IDictionary<string, T?>?)items);
}
