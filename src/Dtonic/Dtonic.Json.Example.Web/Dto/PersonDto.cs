using Dtonic.Json.Base;
using System.Text;
using Dtonic.Json.Extensions;

namespace Dtonic.Json;
public class PersonDto : IJsonSerializable
{
    public JsonString name { get; init; } = JsonString.Unspecified;

    public JsonNumber age { get; init;  } = JsonNumber.Unspecified;

    public JsonBoolean isGoldMember { get; init; } = JsonBoolean.Unspecified;

    public JsonObject<AddressDto> homeAddress { get; init; } = JsonObject<AddressDto>.Unspecified;

    public JsonObject<AddressDto> invoiceAddress { get; init; } = JsonObject<AddressDto>.Unspecified;

    public JsonArray<int> favoriteNumbers { get; init; } = JsonArray<int>.Unspecified;

    public IEnumerable<IJsonType> Elements => [name, age, isGoldMember, homeAddress, invoiceAddress, favoriteNumbers];

    public string ToJsonString()
    {
        var bob = new StringBuilder();
        bob.Append('{');
        bob.Append(name.ToJsonString());
        bob.Append(',');
        bob.Append(age.ToJsonString());
        bob.Append(',');
        bob.Append(isGoldMember.ToJsonString());
        bob.Append(',');
        bob.Append(homeAddress.ToJsonString());
        bob.Append(',');
        bob.Append(invoiceAddress.ToJsonString());
        bob.Append('}');

        return bob.ToString();
    }
}
