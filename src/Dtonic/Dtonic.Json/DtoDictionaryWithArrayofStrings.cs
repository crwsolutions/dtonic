using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithArrayOfStrings : DtoValueBase<IDictionary<string, IEnumerable<string?>?>>
{
    private DtoDictionaryWithArrayOfStrings() { }

    public DtoDictionaryWithArrayOfStrings(IDictionary<string, IEnumerable<string?>?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithArrayOfStrings Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithArrayOfStrings));

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
                    arrayBob.Add(arrayItem is null ? NULL : $"\"{arrayItem}\"");
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
        var dictionary = new Dictionary<string, IEnumerable<string?>?>();
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
                        var lst = new List<string?>();
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
                            else
                            {
                                lst.Add(jsonReader.GetString());
                            }
                        }
                        dictionary.Add(key, lst);
                    }
                }
            }
        }
        Value = dictionary;
    }

    public static implicit operator DtoDictionaryWithArrayOfStrings(Dictionary<string, IEnumerable<string?>?>? items) => new((IDictionary<string, IEnumerable<string?>?>?)items);
}
