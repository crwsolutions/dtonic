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

    public DtoArrayOfStrings anArrayOfStrings { get; init; } = DtoArrayOfStrings.Unspecified;
    public DtoArrayOfNumbers anArrayOfNumbers { get; init; } = DtoArrayOfNumbers.Unspecified;
    public DtoArrayOfBooleans anArrayOfBooleans { get; init; } = DtoArrayOfBooleans.Unspecified;
    public DtoArrayOfObjects<ChildDto> anArrayOfObjects { get; init; } = DtoArrayOfObjects<ChildDto>.Unspecified;

    public DtoDictionaryWithStrings aDictionaryWithStrings { get; init; } = DtoDictionaryWithStrings.Unspecified;
    public DtoDictionaryWithNumbers aDictionaryWithNumbers { get; init; } = DtoDictionaryWithNumbers.Unspecified;
    public DtoDictionaryWithBooleans aDictionaryWithBooleans{ get; init; } = DtoDictionaryWithBooleans.Unspecified;
    public DtoDictionaryWithObjects<ChildDto> aDictionaryWithObjects { get; init; } = DtoDictionaryWithObjects<ChildDto>.Unspecified;

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
            anArrayOfStrings,
            anArrayOfNumbers,
            anArrayOfBooleans,
            anArrayOfObjects,
            aDictionaryWithStrings,
            aDictionaryWithNumbers,
            aDictionaryWithBooleans,
            aDictionaryWithObjects,
        }
        .ToString();
    }
}
