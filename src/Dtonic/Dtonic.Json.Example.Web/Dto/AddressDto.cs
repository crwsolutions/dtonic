using Dtonic.Json.Base;
using Dtonic.Json.Extensions;
using System.Text;
using System.Text.Json;

namespace Dtonic.Json.Example.Web.Dto;

public class AddressDto : IDtonic
{
    public JsonString street { get; init; } = JsonString.Unspecified;
    public JsonString city { get; init; } = JsonString.Unspecified;

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