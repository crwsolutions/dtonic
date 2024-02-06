using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithStrings : DtoValueBase<IDictionary<string, string?>>
{
    private DtoDictionaryWithStrings() { }

    public DtoDictionaryWithStrings(IDictionary<string, string?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithStrings Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithStrings));

    public override string Stringify()
    {
        if (IsNull)
        {
            return "null";
        }
        var bob = new StringifyDictionaryBuilder();
        foreach (var item in Value)
        {
            bob.Add(item.Key, item.Value == null ? "null" : $"\"{item.Value}\"");
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
        var dictionary = new Dictionary<string, string?>();
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
                    string? value = jsonReader.TokenType == JsonTokenType.Null ? null : jsonReader.GetString();
                    dictionary.Add(key, value);
                }
            }
        }
        Value = dictionary;
    }
    public static implicit operator DtoDictionaryWithStrings(Dictionary<string, string?>? items) => new((IDictionary<string, string?>?)items);
}
