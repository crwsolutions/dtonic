using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithNumbers : DtoValueBase<IDictionary<string, decimal?>>
{
    private DtoDictionaryWithNumbers() { }

    public DtoDictionaryWithNumbers(IDictionary<string, decimal?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithNumbers Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithNumbers));

    public override string Stringify()
    {
        if (IsNull)
        {
            return NULL;
        }
        var bob = new StringifyDictionaryBuilder();
        foreach (var item in Value)
        {
            bob.Add(item.Key, item.Value is null ? NULL : item.Value.Value.ToString(CultureInfo.InvariantCulture));
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
        var dictionary = new Dictionary<string, decimal?>();
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
                    decimal? value = jsonReader.TokenType == JsonTokenType.Null ? null : jsonReader.GetDecimal();
                    dictionary.Add(key, value);
                }
            }
        }
        Value = dictionary;
    }

    public static implicit operator DtoDictionaryWithNumbers(Dictionary<string, decimal?>? items) => new((IDictionary<string, decimal?>?)items);
}
