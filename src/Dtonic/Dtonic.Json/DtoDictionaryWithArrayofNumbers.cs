using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithArrayofNumbers : DtoValueBase<IDictionary<string, IEnumerable<decimal?>?>>
{
    private DtoDictionaryWithArrayofNumbers() { }

    public DtoDictionaryWithArrayofNumbers(IDictionary<string, IEnumerable<decimal?>?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithArrayofNumbers Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithArrayofNumbers));

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

    public static implicit operator DtoDictionaryWithArrayofNumbers(Dictionary<string, IEnumerable<decimal?>?>? items) => new((IDictionary<string, IEnumerable<decimal?>?>?)items);
}
