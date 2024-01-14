using System.Text.Json;

namespace Dtonic.Json.Extensions;
public static class JsonDeserializationExtensions
{
    public static JsonString ParseToJsonString(this Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return new JsonString(null);
        }
        if (jsonReader.TokenType == JsonTokenType.String)
        {
            var s = jsonReader.GetString();
            return new JsonString(s);
        }
        throw new Exception("Unknown type");
    }
}
