using Dtonic.Json;
using Dtonic.Json.Base;
using Dtonic.Json.Extensions;

namespace TestClasses;

public class TestDto : IJsonSerializable, IJsonDeserializable
{
    public TestDto() { }

    public JsonString street { get; set; } = JsonString.Unspecified;
    public JsonNumber number { get; set; } = JsonNumber.Unspecified;
    public JsonBoolean isTrue { get; set; } = JsonBoolean.Unspecified;

    public string Stringify()
    {
        var items = new List<string>();
        if (street.IsSet)
        {
            items.Add(street.Stringify());
        }

        var bob = new System.Text.StringBuilder();
        _ = bob.Append('{')
        .Append(string.Join(",", items))
        .Append('}');

        return bob.ToString();
    }

    public void Parse(System.Text.Json.Utf8JsonReader jsonReader)
    {
        while (jsonReader.Read())
        {
            if (jsonReader.TokenType == System.Text.Json.JsonTokenType.PropertyName)
            {
                switch (jsonReader.GetString())
                {
                    case nameof(street):
                        street = jsonReader.ParseToJsonString();
                        break;
                    case nameof(number):
                        number = jsonReader.ParseToJsonNumber();
                        break;
                    case nameof(isTrue):
                        isTrue = jsonReader.ParseToJsonBoolean();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}