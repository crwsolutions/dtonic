using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithArrayOfNumbers : DtoValueBase<IDictionary<string, IEnumerable<decimal?>?>>
{
    private DtoDictionaryWithArrayOfNumbers() { }

    public DtoDictionaryWithArrayOfNumbers(IDictionary<string, IEnumerable<decimal?>?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithArrayOfNumbers Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithArrayOfNumbers));

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
                    arrayBob.Add(arrayItem is null ? NULL : arrayItem.Value.ToString(CultureInfo.InvariantCulture));
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
        var dictionary = new Dictionary<string, IEnumerable<decimal?>?>();
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
                    if (jsonReader.TokenType == JsonTokenType.StartArray)
                    {
                        var lst = new List<decimal?>();
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
                                lst.Add(jsonReader.GetDecimal());
                            }
                        }
                        dictionary.Add(key, lst);
                    }
                }
            }
        }
        Value = dictionary;
    }

    public static implicit operator DtoDictionaryWithArrayOfNumbers(Dictionary<string, IEnumerable<decimal?>?>? items) => new((IDictionary<string, IEnumerable<decimal?>?>?)items);
}
