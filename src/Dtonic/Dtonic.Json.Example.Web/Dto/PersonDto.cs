using Dtonic.Json.Base;
using System.Text;
using Dtonic.Json.Extensions;
using Dtonic.Json.Example.Web.Dto;

namespace Dtonic.Json;
public class PersonDto : IJsonSerializable
{
    public JsonString name { get; init; } = JsonString.Unspecified;

    public JsonNumber age { get; init;  } = JsonNumber.Unspecified;

    public JsonBoolean isGoldMember { get; init; } = JsonBoolean.Unspecified;

    public JsonObject<AddressDto> homeAddress { get; init; } = JsonObject<AddressDto>.Unspecified;

    public JsonObject<AddressDto> invoiceAddress { get; init; } = JsonObject<AddressDto>.Unspecified;

    public JsonArray<int> favoriteNumbers { get; init; } = JsonArray<int>.Unspecified;

    [System.Text.Json.Serialization.JsonIgnore]
    public IEnumerable<IJsonType> Elements => [name, age, isGoldMember, homeAddress, invoiceAddress, favoriteNumbers];

    public string ToJsonString()
    {
        var items = new List<string>();
        if (name.IsSet)
        {
            items.Add(name.ToJsonString());
        }
        if (age.IsSet)
        {
            items.Add(age.ToJsonString());
        }
        if (isGoldMember.IsSet)
        {
            items.Add(isGoldMember.ToJsonString());
        }
        if (favoriteNumbers.IsSet)
        {
            items.Add(favoriteNumbers.ToJsonString());
        }
        if (homeAddress.IsSet)
        {
            items.Add(homeAddress.ToJsonString());
        }
        if (invoiceAddress.IsSet)
        {
            items.Add(invoiceAddress.ToJsonString());
        }
        var bob = new StringBuilder();
        bob.Append('{')
        .Append(string.Join(", ", items))
        .Append('}');

        return bob.ToString();
    }
}
