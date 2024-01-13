using Dtonic.Json.Base;
using System.Text;
using Dtonic.Json.Extensions;

namespace Dtonic.Json;

public class AddressDto : IJsonSerializable
{
    public JsonString street { get; init; } = JsonString.Unspecified;
    public JsonString city { get; init; } = JsonString.Unspecified;

    public string ToJsonString()
    {
        var bob = new StringBuilder();
        bob.Append("{");
        bob.Append(street.ToJsonString());
        bob.Append(city.ToJsonString());
        bob.Append("}");

        return bob.ToString();
    }
}