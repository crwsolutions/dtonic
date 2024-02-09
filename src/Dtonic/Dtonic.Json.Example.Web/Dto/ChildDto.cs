using Dtonic.Dto.Base;
using System.Text.Json;

namespace Dtonic.Dto.Example.Web.Dto;

public class ChildDto : IDtonic
{
    public DtoString aString { get; init; } = DtoString.Unspecified;
    public DtoNumber aNumber { get; init; } = DtoNumber.Unspecified;

    public void Parse(ref System.Text.Json.Utf8JsonReader jsonReader)
    {
        while (jsonReader.Read())
        {

            if (jsonReader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

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
                    default:
                        break;
                }
            }
        }
    }

    public string Stringify()
    {
        return new Utils.StringifyObjectBuilder
        {
            aString,
            aNumber
        }.ToString();
    }
}