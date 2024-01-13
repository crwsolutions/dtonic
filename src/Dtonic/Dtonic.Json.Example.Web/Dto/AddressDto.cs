using Dtonic.Json.Base;
using Dtonic.Json.Extensions;
using System.Text;

namespace Dtonic.Json.Example.Web.Dto;

public class AddressDto : IJsonSerializable
{
    public JsonString street { get; init; } = JsonString.Unspecified;
    public JsonString city { get; init; } = JsonString.Unspecified;

    public string ToJsonString()
    {
        var items = new List<string>();
        if (street.IsSet)
        {
            items.Add(street.ToJsonString());
        }

        if (city.IsSet)
        {
            items.Add(city.ToJsonString());
        }

        var bob = new StringBuilder();
        _ = bob.Append('{')
        .Append(string.Join(", ", items))
        .Append('}');

        return bob.ToString();
    }
}