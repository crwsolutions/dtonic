using Dtonic.Json;
using Dtonic.Json.Base;
using Dtonic.Json.Extensions;

namespace TestClasses;

public class TestDto : IJsonSerializable
{
    public TestDto() { }

    public JsonString street { get; init; } = JsonString.Unspecified;

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

    public TestDto(System.Text.Json.Utf8JsonReader jsonReader)
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
                    default:
                        break;
                }
            }
        }
    }
}