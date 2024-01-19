using Dtonic.Json;
using Dtonic.Json.Base;
using Dtonic.Json.Extensions;

namespace TestClasses;

public class TestDto : IDtonic
{
    public TestDto() { }

    public JsonString street { get; set; } = JsonString.Unspecified;
    public JsonNumber number { get; set; } = JsonNumber.Unspecified;
    public JsonBoolean isTrue { get; set; } = JsonBoolean.Unspecified;
    public JsonObject<TestDto> childTestDto { get; set; } = JsonObject<TestDto>.Unspecified;
    public JsonArrayOfObjects<TestDto> array { get; set; } = JsonArrayOfObjects<TestDto>.Unspecified;
    public JsonArrayOfNumbers arrayI { get; set; } = JsonArrayOfNumbers.Unspecified;
    public JsonArrayOfStrings arrayS { get; set; } = JsonArrayOfStrings.Unspecified;
    public JsonArrayOfBooleans arrayB { get; set; } = JsonArrayOfBooleans.Unspecified;

    public string Stringify()
    {
        var items = new List<string>();
        items.AddIfSpecified(street);


        var bob = new System.Text.StringBuilder();
        _ = bob.Append('{')
        .Append(string.Join(",", items))
        .Append('}');

        return bob.ToString();
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