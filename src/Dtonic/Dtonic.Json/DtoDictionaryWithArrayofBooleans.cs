using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithArrayOfBooleans : DtoValueBase<IDictionary<string, IEnumerable<bool?>?>>
{
    private DtoDictionaryWithArrayOfBooleans() { }

    public DtoDictionaryWithArrayOfBooleans(IDictionary<string, IEnumerable<bool?>?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithArrayOfBooleans Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithArrayOfBooleans));

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
                    arrayBob.Add(arrayItem is null ? NULL : arrayItem.ToString()!.ToLower());
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
        var dictionary = new Dictionary<string, IEnumerable<bool?>?>();
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
                        var lst = new List<bool?>();
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
                        dictionary.Add(key, lst);
                    }
                }
            }
        }
        Value = dictionary;
    }

    public static implicit operator DtoDictionaryWithArrayOfBooleans(Dictionary<string, IEnumerable<bool?>?>? items) => new((IDictionary<string, IEnumerable<bool?>?>?)items);
}
