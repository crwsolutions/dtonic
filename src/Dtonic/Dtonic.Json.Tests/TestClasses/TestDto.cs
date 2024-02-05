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

    public string Stringify()
    {
        return new StringifyObjectBuilder
        {
            aString,
            aNumber,
            aBoolean,
            anObject,
            anArrayOfObjects,
            anArrayOfNumbers,
            anArrayOfStrings,
            anArrayOfBooleans
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