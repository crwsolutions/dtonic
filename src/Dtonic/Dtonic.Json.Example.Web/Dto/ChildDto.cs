using Dtonic.Dto.Base;
using System.Text.Json;

namespace Dtonic.Dto.Example.Web.Dto;

public class ChildDto : IDtonic
{
    public DtoString aString { get; init; } = DtoString.Unspecified;
    public DtoNumber aNumber { get; init; } = DtoNumber.Unspecified;

    public void Parse(ref Utf8JsonReader jsonReader) => throw new NotImplementedException();

    public string Stringify()
    {
        return new Utils.StringifyObjectBuilder
        {
            aString,
            aNumber
        }.ToString();
    }
}