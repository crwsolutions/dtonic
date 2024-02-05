using Dtonic.Dto;
using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;

namespace TestClasses;

public class TestDto : IDtonic
{
    public TestDto() { }

    public DtoString street { get; set; } = DtoString.Unspecified;
    public DtoNumber number { get; set; } = DtoNumber.Unspecified;
    public DtoBoolean isTrue { get; set; } = DtoBoolean.Unspecified;
    public DtoObject<TestDto> childTestDto { get; set; } = DtoObject<TestDto>.Unspecified;
    public DtoArrayOfStrings arrayS { get; set; } = DtoArrayOfStrings.Unspecified;
    public DtoArrayOfNumbers arrayI { get; set; } = DtoArrayOfNumbers.Unspecified;
    public DtoArrayOfBooleans arrayB { get; set; } = DtoArrayOfBooleans.Unspecified;
    public DtoArrayOfObjects<TestDto> array { get; set; } = DtoArrayOfObjects<TestDto>.Unspecified;

    public string Stringify()
    {
        return new StringifyObjectBuilder
        {
            street,
            number,
            isTrue,
            childTestDto,
            array,
            arrayI,
            arrayS,
            arrayB
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
                    case nameof(street):
                        street.Parse(ref jsonReader);
                        break;
                    case nameof(number):
                        number.Parse(ref jsonReader);
                        break;
                    case nameof(isTrue):
                        isTrue.Parse(ref jsonReader);
                        break;
                    case nameof(childTestDto):
                        childTestDto.Parse(ref jsonReader);
                        break;
                    case nameof(array):
                        array.Parse(ref jsonReader);
                        break;
                    case nameof(arrayS):
                        arrayS.Parse(ref jsonReader);
                        break;
                    case nameof(arrayI):
                        arrayI.Parse(ref jsonReader);
                        break;
                    case nameof(arrayB):
                        arrayB.Parse(ref jsonReader);
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