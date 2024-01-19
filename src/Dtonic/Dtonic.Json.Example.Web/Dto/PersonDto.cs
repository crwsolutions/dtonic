using Dtonic.Json.Base;
using Dtonic.Json.Example.Web.Dto;
using Dtonic.Json.Utils;
using System.Text.Json;

namespace Dtonic.Json;
public class PersonDto : IDtonic
{
    public JsonString name { get; init; } = JsonString.Unspecified;

    public JsonNumber age { get; init; } = JsonNumber.Unspecified;

    public JsonBoolean isGoldMember { get; init; } = JsonBoolean.Unspecified;

    public JsonObject<AddressDto> homeAddress { get; init; } = JsonObject<AddressDto>.Unspecified;

    public JsonObject<AddressDto> invoiceAddress { get; init; } = JsonObject<AddressDto>.Unspecified;

    public JsonArrayOfNumbers favoriteNumbers { get; init; } = JsonArrayOfNumbers.Unspecified;

    public JsonDictionary<AddressDto> addressList { get; init; } = JsonDictionary<AddressDto>.Unspecified;

    [System.Text.Json.Serialization.JsonIgnore]
    public IEnumerable<IJsonType> Elements => [name, age, isGoldMember, homeAddress, invoiceAddress, favoriteNumbers];

    public void Parse(ref Utf8JsonReader jsonReader) => throw new NotImplementedException();

    public string Stringify()
    {
        return new StringifyObjectBuilder
        {
            name,
            age,
            isGoldMember,
            favoriteNumbers,
            homeAddress,
            invoiceAddress,
            addressList,
        }
        .ToString();
    }
}
