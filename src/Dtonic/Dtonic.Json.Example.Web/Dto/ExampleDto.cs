using Dtonic.Dto.Base;
using Dtonic.Dto.Example.Web.Dto;
using Dtonic.Dto.Utils;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace Dtonic.Dto;

[BindingBehavior(BindingBehavior.Never)]
public class ExampleDto : IDtonic
{
    public DtoString aString { get; init; } = DtoString.Unspecified;
    public DtoNumber aNumber { get; init; } = DtoNumber.Unspecified;
    public DtoBoolean aBoolean { get; init; } = DtoBoolean.Unspecified;
    public DtoObject<ChildDto> anObject { get; init; } = DtoObject<ChildDto>.Unspecified;

    public DtoArrayOfStrings anArrayOfStrings { get; init; } = DtoArrayOfStrings.Unspecified;
    public DtoArrayOfNumbers anArrayOfNumbers { get; init; } = DtoArrayOfNumbers.Unspecified;
    public DtoArrayOfBooleans anArrayOfBooleans { get; init; } = DtoArrayOfBooleans.Unspecified;
    public DtoArrayOfObjects<ChildDto> anArrayOfObjects { get; init; } = DtoArrayOfObjects<ChildDto>.Unspecified;

    public DtoDictionaryWithStrings aDictionaryWithStrings { get; init; } = DtoDictionaryWithStrings.Unspecified;
    public DtoDictionaryWithNumbers aDictionaryWithNumbers { get; init; } = DtoDictionaryWithNumbers.Unspecified;
    public DtoDictionaryWithBooleans aDictionaryWithBooleans { get; init; } = DtoDictionaryWithBooleans.Unspecified;
    public DtoDictionaryWithObjects<ChildDto> aDictionaryWithObjects { get; init; } = DtoDictionaryWithObjects<ChildDto>.Unspecified;

    public DtoDictionaryWithArrayOfBooleans aDictionaryWithArrayOfBooleans { get; init; } = DtoDictionaryWithArrayOfBooleans.Unspecified;
    public DtoDictionaryWithArrayOfStrings aDictionaryWithArrayOfStrings { get; init; } = DtoDictionaryWithArrayOfStrings.Unspecified;
    public DtoDictionaryWithArrayOfNumbers aDictionaryWithArrayOfNumbers { get; init; } = DtoDictionaryWithArrayOfNumbers.Unspecified;
    public DtoDictionaryWithArrayOfObjects<ChildDto> aDictionaryWithArrayOfObjects { get; init; } = DtoDictionaryWithArrayOfObjects<ChildDto>.Unspecified;

    [System.Text.Json.Serialization.JsonIgnore]
    public IEnumerable<IDtoValue> Elements => [aString, aNumber, aBoolean, anObject, anArrayOfNumbers];

    public void Parse(ref System.Text.Json.Utf8JsonReader jsonReader)
    {
        while (jsonReader.Read())
        {
            if (jsonReader.TokenType == System.Text.Json.JsonTokenType.EndObject)
            {
                break;
            }

            if (jsonReader.TokenType == JsonTokenType.PropertyName)
            {
                switch (jsonReader.GetString())
                {
                    case nameof(aString):
                        aString.Parse(ref jsonReader);
                        break;
                    case nameof(aNumber):
                        aNumber.Parse(ref jsonReader);
                        break;
                    case nameof(aBoolean):
                        aBoolean.Parse(ref jsonReader);
                        break;
                    case nameof(anObject):
                        anObject.Parse(ref jsonReader);
                        break;
                    case nameof(anArrayOfObjects):
                        anArrayOfObjects.Parse(ref jsonReader);
                        break;
                    case nameof(anArrayOfStrings):
                        anArrayOfStrings.Parse(ref jsonReader);
                        break;
                    case nameof(anArrayOfNumbers):
                        anArrayOfNumbers.Parse(ref jsonReader);
                        break;
                    case nameof(anArrayOfBooleans):
                        anArrayOfBooleans.Parse(ref jsonReader);
                        break;
                    case nameof(aDictionaryWithObjects):
                        aDictionaryWithObjects.Parse(ref jsonReader);
                        break;
                    case nameof(aDictionaryWithStrings):
                        aDictionaryWithStrings.Parse(ref jsonReader);
                        break;
                    case nameof(aDictionaryWithNumbers):
                        aDictionaryWithNumbers.Parse(ref jsonReader);
                        break;
                    case nameof(aDictionaryWithBooleans):
                        aDictionaryWithBooleans.Parse(ref jsonReader);
                        break;
                    case nameof(aDictionaryWithArrayOfBooleans):
                        aDictionaryWithArrayOfBooleans.Parse(ref jsonReader);
                        break;
                    case nameof(aDictionaryWithArrayOfNumbers):
                        aDictionaryWithArrayOfNumbers.Parse(ref jsonReader);
                        break;
                    case nameof(aDictionaryWithArrayOfStrings):
                        aDictionaryWithArrayOfStrings.Parse(ref jsonReader);
                        break;
                    case nameof(aDictionaryWithArrayOfObjects):
                        aDictionaryWithArrayOfObjects.Parse(ref jsonReader);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public string Stringify()
    {
        return new StringifyObjectBuilder
        {
            aString,
            aNumber,
            aBoolean,
            anObject,

            anArrayOfStrings,
            anArrayOfNumbers,
            anArrayOfBooleans,
            anArrayOfObjects,

            aDictionaryWithStrings,
            aDictionaryWithNumbers,
            aDictionaryWithBooleans,
            aDictionaryWithObjects,

            aDictionaryWithArrayOfBooleans,
            aDictionaryWithArrayOfNumbers,
            aDictionaryWithArrayOfStrings,
            aDictionaryWithArrayOfObjects,
        }
        .ToString();
    }
}
