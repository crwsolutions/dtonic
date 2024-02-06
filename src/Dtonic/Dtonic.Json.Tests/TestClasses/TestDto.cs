using Dtonic.Dto;
using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;

namespace TestClasses;

public class TestDto : IDtonic
{
    public TestDto() { }

    public DtoString aString { get; set; } = DtoString.Unspecified;
    public DtoNumber aNumber { get; set; } = DtoNumber.Unspecified;
    public DtoBoolean aBoolean { get; set; } = DtoBoolean.Unspecified;
    public DtoObject<TestDto> anObject { get; set; } = DtoObject<TestDto>.Unspecified;

    public DtoArrayOfStrings anArrayOfStrings { get; set; } = DtoArrayOfStrings.Unspecified;
    public DtoArrayOfNumbers anArrayOfNumbers { get; set; } = DtoArrayOfNumbers.Unspecified;
    public DtoArrayOfBooleans anArrayOfBooleans { get; set; } = DtoArrayOfBooleans.Unspecified;
    public DtoArrayOfObjects<TestDto> anArrayOfObjects { get; set; } = DtoArrayOfObjects<TestDto>.Unspecified;

    public DtoDictionaryWithStrings aDictionaryWithStrings { get; set; } = DtoDictionaryWithStrings.Unspecified;
    public DtoDictionaryWithNumbers aDictionaryWithNumbers { get; set; } = DtoDictionaryWithNumbers.Unspecified;
    public DtoDictionaryWithBooleans aDictionaryWithBooleans { get; set; } = DtoDictionaryWithBooleans.Unspecified;
    public DtoDictionaryWithObjects<TestDto> aDictionaryWithObjects { get; set; } = DtoDictionaryWithObjects<TestDto>.Unspecified;

    public DtoDictionaryWithArrayOfBooleans aDictionaryWithArrayOfBooleans { get; set; } = DtoDictionaryWithArrayOfBooleans.Unspecified;
    public DtoDictionaryWithArrayOfStrings aDictionaryWithArrayOfStrings { get; set; } = DtoDictionaryWithArrayOfStrings.Unspecified;
    public DtoDictionaryWithArrayOfNumbers aDictionaryWithArrayOfNumbers { get; set; } = DtoDictionaryWithArrayOfNumbers.Unspecified;
    public DtoDictionaryWithArrayOfObjects<TestDto> aDictionaryWithArrayOfObjects { get; set; } = DtoDictionaryWithArrayOfObjects<TestDto>.Unspecified;

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
            aDictionaryWithArrayOfStrings,
            aDictionaryWithArrayOfNumbers,
            aDictionaryWithArrayOfObjects,

        }
        .ToString();
    }

    public void Parse(ref System.Text.Json.Utf8JsonReader jsonReader)
    {
        while (jsonReader.Read())
        {
            if (jsonReader.TokenType == System.Text.Json.JsonTokenType.PropertyName)
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

            if (jsonReader.TokenType == System.Text.Json.JsonTokenType.EndObject)
            {
                break;
            }
        }
    }
}