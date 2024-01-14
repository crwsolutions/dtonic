using Dtonic.Json;
using Dtonic.Json.Base;
using Dtonic.Json.Extensions;

namespace TestClasses;

public class TestDto : IJsonSerializable
{
    public JsonString street { get; init; } = JsonString.Unspecified;

    public string ToJsonString()
    {
        var items = new List<string>();
        if (street.IsSet)
        {
            items.Add(street.ToJsonString());
        }

        var bob = new System.Text.StringBuilder();
        _ = bob.Append('{')
        .Append(string.Join(",", items))
        .Append('}');

        return bob.ToString();
    }
}