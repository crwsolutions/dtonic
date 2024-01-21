using Dtonic.Dto.Base;
using System.Text.Json;

namespace Dtonic.Dto.Example.Web.Dto;

public class AddressDto : IDtonic
{
    public DtoString street { get; init; } = DtoString.Unspecified;
    public DtoString city { get; init; } = DtoString.Unspecified;

    public void Parse(ref Utf8JsonReader jsonReader) => throw new NotImplementedException();

    public string Stringify()
    {
        return new Utils.StringifyObjectBuilder
        {
            street,
            city
        }.ToString();
    }
}