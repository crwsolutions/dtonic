using Dtonic.Dto.Base;
using Dtonic.Dto.Example.Web.Dto;
using Dtonic.Dto.Utils;
using System.Text.Json;

namespace Dtonic.Dto;
public class ExampleDto : IDtonic
{
    public DtoString aString { get; init; } = DtoString.Unspecified;
    public DtoNumber aNumber { get; init; } = DtoNumber.Unspecified;
    public DtoBoolean aBoolean { get; init; } = DtoBoolean.Unspecified;
    public DtoObject<ChildDto> aChild { get; init; } = DtoObject<ChildDto>.Unspecified;

    public DtoArrayOfNumbers anArrayOfNumbers { get; init; } = DtoArrayOfNumbers.Unspecified;
    public DtoArrayOfBooleans anArrayOfBooleans { get; init; } = DtoArrayOfBooleans.Unspecified;
    public DtoArrayOfStrings anArrayOfStrings { get; init; } = DtoArrayOfStrings.Unspecified;
    public DtoArrayOfObjects<ChildDto> anArrayOfObjects { get; init; } = DtoArrayOfObjects<ChildDto>.Unspecified;

    public DtoDictionaryWithObjects<ChildDto> aDictionaryOfObjects { get; init; } = DtoDictionaryWithObjects<ChildDto>.Unspecified;

    [System.Text.Json.Serialization.JsonIgnore]
    public IEnumerable<IDtoValue> Elements => [aString, aNumber, aBoolean, aChild, anArrayOfNumbers];

    public void Parse(ref Utf8JsonReader jsonReader) => throw new NotImplementedException();

    public string Stringify()
    {
        return new StringifyObjectBuilder
        {
            aString,
            aNumber,
            aBoolean,
            aChild,
            anArrayOfNumbers,
            anArrayOfStrings,
            anArrayOfBooleans,
            anArrayOfObjects,
            aDictionaryOfObjects,
        }
        .ToString();
    }
}
