using Dtonic.Json.Base;
using System.Text;
using System.Text.Json;

namespace Dtonic.Json.Extensions;
public static class JsonDeserializationExtensions
{
    public static T Parse<T>(this string s) where T : IJsonDeserializable, new()
    {
        var t = new T();
        var options = new JsonReaderOptions
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip
        };
        var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(s), options);
        t.Parse(jsonReader);
        return t;
    }

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

    public static JsonNumber ParseToJsonNumber(this Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return new JsonNumber(null);
        }
        if (jsonReader.TokenType == JsonTokenType.Number)
        {
            var s = jsonReader.GetDecimal();
            return new JsonNumber(s);
        }
        throw new Exception("Unknown type");
    }

    public static JsonBoolean ParseToJsonBoolean(this Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return new JsonBoolean(null);
        }
        if (jsonReader.TokenType == JsonTokenType.True)
        {
            return new JsonBoolean(true);
        }
        if (jsonReader.TokenType == JsonTokenType.False)
        {
            return new JsonBoolean(false);
        }
        throw new Exception("Unknown type");
    }
}
