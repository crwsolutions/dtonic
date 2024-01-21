using Dtonic.Dto.Base;
using Dtonic.Dto.Example.Web.Dto;
using Dtonic.Dto.Utils;
using System.Text.Json;

namespace Dtonic.Dto;
public class PersonDto : IDtonic
{
    public DtoString name { get; init; } = DtoString.Unspecified;

    public DtoNumber age { get; init; } = DtoNumber.Unspecified;

    public DtoBoolean isGoldMember { get; init; } = DtoBoolean.Unspecified;

    public DtoObject<AddressDto> homeAddress { get; init; } = DtoObject<AddressDto>.Unspecified;

    public DtoObject<AddressDto> invoiceAddress { get; init; } = DtoObject<AddressDto>.Unspecified;

    public DtoArrayOfNumbers favoriteNumbers { get; init; } = DtoArrayOfNumbers.Unspecified;

    public DtoDictionaryOfObjects<AddressDto> addressList { get; init; } = DtoDictionaryOfObjects<AddressDto>.Unspecified;

    [System.Text.Json.Serialization.JsonIgnore]
    public IEnumerable<IDtoValue> Elements => [name, age, isGoldMember, homeAddress, invoiceAddress, favoriteNumbers];

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
