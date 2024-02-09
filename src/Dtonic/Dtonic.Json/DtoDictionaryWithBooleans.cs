using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithBooleans : DtoValueBase<IDictionary<string, bool?>>
{
    private DtoDictionaryWithBooleans() { }

    public DtoDictionaryWithBooleans(IDictionary<string, bool?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithBooleans Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithBooleans));

    public override string Stringify()
    {
        if (IsNull)
        {
            return NULL;
        }
        var bob = new StringifyDictionaryBuilder();
        foreach (var item in Value)
        {
            bob.Add(item.Key, item.Value is null ? NULL : item.Value.Value.ToString(CultureInfo.InvariantCulture).ToLower());
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
        var dictionary = new Dictionary<string, bool?>();
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
                    bool? value = jsonReader.TokenType == JsonTokenType.Null ? null : jsonReader.GetBoolean();
                    dictionary.Add(key, value);
                }
            }
        }
        Value = dictionary;
    }

    public static implicit operator DtoDictionaryWithBooleans(Dictionary<string, bool?>? items) => new((IDictionary<string, bool?>?)items);
}
